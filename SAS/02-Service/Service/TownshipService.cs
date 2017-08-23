using Common;
using Common.ProjectHelpers;
using Model.Auth;
using Model.Custom;
using Model.Domain;
using NLog;
using Persistence.DbContextScope;
using Persistence.DbContextScope.Extensions;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Service
{
    public interface ITownshipService
    {
        ResponseHelper InsertOrUpdate(Township model);
        AnexGRIDResponde GetAll(AnexGRID grid);
        IEnumerable<Township> GetAll();
        Township Get(int id);
        ResponseHelper AddFile(HttpPostedFileBase file);
    }

    public class TownshipService : ITownshipService
    {
        private readonly ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Township> _townshipRepository;
        private readonly IRepository<Locality> _localityRepository;

        public TownshipService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<Township> townshipRepository,
            IRepository<Locality> localityRepository
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _townshipRepository = townshipRepository;
            _localityRepository = localityRepository;
        }

        public ResponseHelper InsertOrUpdate(Township model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    if (model.TownshipId > 0)
                    {
                        var originaltown = _townshipRepository.Single(x => x.TownshipId == model.TownshipId);

                        originaltown.Name = model.Name;

                        _townshipRepository.Update(originaltown);
                    }
                    else
                    {
                        _townshipRepository.Insert(model);
                    }

                    ctx.SaveChanges();
                }

                rh.SetResponse(true);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, e.Message);
            }

            return rh;
        }

        public AnexGRIDResponde GetAll(AnexGRID grid)
        {
            grid.Inicializar();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    var town = ctx.GetEntity<Township>();
                    var location = ctx.GetEntity<Locality>();

                    var query = (
                        from t in town
                        select new TownshipForGridView
                        {
                            Id = t.TownshipId,
                            Name = t.Name,
                            Localities = location.Where(x => x.TownshipId == t.TownshipId).OrderBy(x => x.Name).Select(x => x.Name).ToList()
                        });

                    if (grid.columna == "Id")
                    {
                        query = grid.columna_orden == "ASC" ? query.OrderBy(x => x.Id)
                                                            : query.OrderByDescending(x => x.Id);
                    }
                    if (grid.columna == "Name")
                    {
                        query = grid.columna_orden == "ASC" ? query.OrderBy(x => x.Name)
                                                            : query.OrderByDescending(x => x.Name);
                    }

                    foreach (var f in grid.filtros)
                    {
                        if (f.columna == "Name")
                            query = query.Where(x => x.Name.Contains(f.valor));
                    }

                    var data = query
                               .Skip(grid.pagina)
                               .Take(grid.limite)
                               .ToList();
                    var total = query.Count();

                    grid.SetData(data, total);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return grid.responde();
        }

        public IEnumerable<Township> GetAll()
        {
            var result = new List<Township>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _townshipRepository.GetAll().OrderBy(x => x.Name).ToList();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public Township Get(int id)
        {
            var result = new Township();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _townshipRepository.SingleOrDefault(x => x.TownshipId == id);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public ResponseHelper AddFile(HttpPostedFileBase file)
        {
            var rh = new ResponseHelper();

            try
            {
                DataSet ds = new DataSet();

                // Creamos la ruta
                var path = DirectoryPath.CollegeFile(DateTime.Now);
                DirectoryPath.Create(path);

                // Ahora vamos a crear los nombres para el archivo
                var fileName = path
                               + DateTime.Now.ToString("MMdd")
                               + Path.GetExtension(file.FileName);

                // La ruta completa
                var fullPath = HttpContext.Current.Server.MapPath("~/" + fileName);

                // La ruta donde lo vamos guardar
                file.SaveAs(fullPath);

                #region cadena de conexion del excel

                string excelConnectionString = string.Empty;

                excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                fullPath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";

                //connection String for xls file format.
                if (Path.GetExtension(file.FileName) == ".xls")
                {
                    excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                    fullPath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                }

                //connection String for xlsx file format.
                else if (Path.GetExtension(file.FileName) == ".xlsx")
                {
                    excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                    fullPath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                }
                #endregion

                #region crear una conexion con el excel, busqueda de los registros a importar

                //crear la conexion del excel y abrir conexion
                OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);

                excelConnection.Open();

                DataTable dt = new DataTable();

                dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dt == null)
                {
                    return null;
                }

                String[] excelSheets = new String[dt.Rows.Count];

                int t = 0;
                //excel data saves in temp file here.
                foreach (DataRow row in dt.Rows)
                {
                    excelSheets[t] = row["TABLE_NAME"].ToString();
                    t++;
                }
                OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);


                string query = string.Format("Select * from [{0}]", excelSheets[0]);
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
                {
                    dataAdapter.Fill(ds);
                }
                #endregion

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    var newTownship = new Township();

                    var name = ds.Tables[0].Rows[i][0].ToString();

                    var hastownperlocality = false;


                    using (var ctx = _dbContextScopeFactory.Create())
                    {
                        var hastownship = _townshipRepository.Find(x =>
                                x.Name == name
                            ).Any();

                        if (!hastownship)
                        {
                            newTownship.Name = ds.Tables[0].Rows[i][0].ToString();
                            _townshipRepository.Insert(newTownship);
                            ctx.SaveChanges();

                           
                        }

                        hastownperlocality = _townshipRepository.Find(x =>
                               x.Name == name
                           ).Any(); ;
                    }

                    if (hastownperlocality)
                    {
                        using (var ctx = _dbContextScopeFactory.Create())
                        {
                            var locality = new Locality();
                            var Id = _townshipRepository.Single(x => x.Name == name).TownshipId;
                            var loc = ds.Tables[0].Rows[i][1].ToString();

                            var hascontact = _localityRepository.Find(x =>
                                x.TownshipId == Id && x.code == loc
                            ).Any();

                            if (!hascontact)
                            {
                                locality.TownshipId = Id;
                                locality.Name = ds.Tables[0].Rows[i][2].ToString();
                                locality.code = ds.Tables[0].Rows[i][1].ToString();
                                locality.latitude = ds.Tables[0].Rows[i][3].ToString();
                                locality.Length = ds.Tables[0].Rows[i][4].ToString();
                                locality.Altitude = Convert.ToInt32(ds.Tables[0].Rows[i][5].ToString());

                                _localityRepository.Insert(locality);
                            }
                            else
                            {
                                locality = _localityRepository.FirstOrDefault(x => x.code == loc);

                                locality.TownshipId = Id;
                                locality.Name = ds.Tables[0].Rows[i][2].ToString();
                                locality.code = ds.Tables[0].Rows[i][1].ToString();
                                locality.latitude = ds.Tables[0].Rows[i][3].ToString();
                                locality.Length = ds.Tables[0].Rows[i][4].ToString();
                                locality.Altitude = Convert.ToInt32(ds.Tables[0].Rows[i][5].ToString());

                                _localityRepository.Update(locality);
                            }

                            ctx.SaveChanges();

                        }
                    }
                }

                rh.SetResponse(true);
            }

            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, e.Message);
            }

            return rh;
        }

    }
}
