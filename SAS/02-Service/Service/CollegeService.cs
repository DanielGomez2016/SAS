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
    public interface ICollegeService
    {
        ResponseHelper InsertOrUpdate(College model);
        AnexGRIDResponde GetAll(AnexGRID grid);
        IEnumerable<College> GetAll();
        College Get(int id);
        ResponseHelper AddFile(HttpPostedFileBase file);
    }

    public class CollegeService : ICollegeService
    {
        private readonly ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<College> _CollegeRepository;
        private readonly IRepository<Contact> _contactRepository;


        public CollegeService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<College> CollegeRepository,
            IRepository<Contact> contactRepository
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _CollegeRepository = CollegeRepository;
            _contactRepository = contactRepository;
        }

        public ResponseHelper InsertOrUpdate(College model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    if (model.LocalityId > 0)
                    {
                        var originalCollege = _CollegeRepository.Single(x => x.LocalityId == model.LocalityId);

                        originalCollege.Name = model.Name;
                        originalCollege.Code = model.Code;
                        originalCollege.Address = model.Address;
                        originalCollege.Turn = model.Turn;
                        originalCollege.Geox = model.Geox;
                        originalCollege.Geoy = model.Geoy;
                        originalCollege.Status = model.Status;
                        originalCollege.Postcode = model.Postcode;
                        originalCollege.Colony = model.Colony;
                        originalCollege.Marginalization = model.Marginalization;
                        originalCollege.Population = model.Population;
                        originalCollege.Zone = model.Zone;
                        originalCollege.LocalityId = model.LocalityId;
                        originalCollege.LevelId = model.LevelId;

                        _CollegeRepository.Update(originalCollege);
                    }
                    else
                    {
                        // Después de insertar el campo Id ya tiene ID
                        _CollegeRepository.Insert(model);
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
                    var college = ctx.GetEntity<College>();
                    var contacts = ctx.GetEntity<Contact>();

                    var query = (
                        from c in college
                        select new CollegeForGridView
                        {
                            Id = c.CollegeId,
                            Name = c.Name,
                            Code = c.Code,
                            Locality = c.Locality.Name + ", " + c.Locality.Township.Name,
                            EducationLevel = c.LevelId > 0 ? c.EducationLevel.Level : "",
                            Principal = contacts.FirstOrDefault(x => x.CollegeId == c.CollegeId).Name,
                            Status = c.Status,
                        });

                    if (grid.columna == "Id")
                    {
                        query = grid.columna_orden == "ASC" ? query.OrderBy(x => x.Name)
                                                            : query.OrderByDescending(x => x.Name);
                    }

                    foreach (var f in grid.filtros)
                    {
                        if (f.columna == "Name")
                            query = query.Where(x => x.Name.Contains(f.valor));
                        if (f.columna == "Code")
                            query = query.Where(x => x.Code.Contains(f.valor));
                        if (f.columna == "Locality")
                            query = query.Where(x => x.Locality.Contains(f.valor));
                        if (f.columna == "EducationLevel")
                            query = query.Where(x => x.EducationLevel.Contains(f.valor));
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

        public IEnumerable<College> GetAll()
        {
            var result = new List<College>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _CollegeRepository.GetAll().OrderBy(x => x.Code).ToList();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public College Get(int id)
        {
            var result = new College();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _CollegeRepository.SingleOrDefault(x => x.CollegeId == id);
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
                    var newCollege = new College();

                    var code = ds.Tables[0].Rows[i][1].ToString();

                    var hascollegeperContact = false;

                    // convertimos el turno que tiene el excel por el valor del catalogo
                    var turn = ds.Tables[0].Rows[i][3].ToString();
                    Enums.Turn EnumTurn = 0;

                    if (turn.StartsWith("MATUTINO-VESPERTINO"))
                        EnumTurn = Enums.Turn.DoubleTurn;
                    if (turn.StartsWith("VESPERTINO"))
                        EnumTurn = Enums.Turn.Evening;
                    if (turn.StartsWith("MATUTINO"))
                        EnumTurn = Enums.Turn.Evening;
                    if (turn.StartsWith("DISCONTINUO"))
                        EnumTurn = Enums.Turn.Discontinued;

                    // convertimos el status que tiene el excel por el valor del catalogo
                    var status = ds.Tables[0].Rows[i][4].ToString();
                    Enums.StatusCollege EnumStatus = 0;

                    if (status.StartsWith("ABIERTA"))
                        EnumStatus = Enums.StatusCollege.Active;
                    if (status.StartsWith("BAJA"))
                        EnumStatus = Enums.StatusCollege.Low;
                    if (status.StartsWith("CLAUSURADO"))
                        EnumStatus = Enums.StatusCollege.Closed;
                    if (status.StartsWith("REAPERTURA"))
                        EnumStatus = Enums.StatusCollege.Reopening;

                    using (var ctx = _dbContextScopeFactory.Create())
                    {
                        var hasCollege = _CollegeRepository.Find(x =>
                                x.Code == code
                            ).Any();

                        if (!hasCollege)
                        {

                            newCollege.Code = ds.Tables[0].Rows[i][1].ToString();
                            newCollege.Name = ds.Tables[0].Rows[i][2].ToString();
                            newCollege.Address = ds.Tables[0].Rows[i][5].ToString();
                            newCollege.LocalityId = Convert.ToInt32(ds.Tables[0].Rows[i][13].ToString());
                            newCollege.Turn = EnumTurn;
                            newCollege.Status = EnumStatus;
                            if (ds.Tables[0].Rows[i][9].ToString() != "")
                            {
                                newCollege.Postcode = Convert.ToInt32(ds.Tables[0].Rows[i][9].ToString());
                            }
                            newCollege.Colony = ds.Tables[0].Rows[i][10].ToString();
                            newCollege.Marginalization = ds.Tables[0].Rows[i][15].ToString();
                            newCollege.Population = ds.Tables[0].Rows[i][16].ToString();
                            if (!ds.Tables[0].Rows[i][23].ToString().Contains("NA"))
                            {
                                newCollege.Zone = Convert.ToInt32(ds.Tables[0].Rows[i][23].ToString());
                            }

                            _CollegeRepository.Insert(newCollege);

                            ctx.SaveChanges();

                            hascollegeperContact = true;
                        }
                        else
                        {
                            newCollege = _CollegeRepository.FirstOrDefault(x => x.Code == code);
                            newCollege.Code = ds.Tables[0].Rows[i][1].ToString();
                            newCollege.Name = ds.Tables[0].Rows[i][2].ToString();
                            newCollege.Address = ds.Tables[0].Rows[i][5].ToString();
                            newCollege.LocalityId = Convert.ToInt32(ds.Tables[0].Rows[i][13].ToString());
                            newCollege.Turn = EnumTurn;
                            newCollege.Status = EnumStatus;

                            if (ds.Tables[0].Rows[i][9].ToString() != "")
                            {
                                newCollege.Postcode = Convert.ToInt32(ds.Tables[0].Rows[i][9].ToString());
                            }

                            newCollege.Colony = ds.Tables[0].Rows[i][10].ToString();
                            newCollege.Marginalization = ds.Tables[0].Rows[i][15].ToString();
                            newCollege.Population = ds.Tables[0].Rows[i][16].ToString();

                            if (!ds.Tables[0].Rows[i][23].ToString().Contains("NA"))
                            {
                                newCollege.Zone = Convert.ToInt32(ds.Tables[0].Rows[i][23].ToString());
                            }

                            _CollegeRepository.Insert(newCollege);

                            ctx.SaveChanges();
                        }
                    }

                    if (hascollegeperContact)
                    {
                        using (var ctx = _dbContextScopeFactory.Create())
                        {
                            var contactCollege = new Contact();
                            var Id = _CollegeRepository.Single(x => x.Code == code).CollegeId;

                            var hascontact = _contactRepository.Find(x =>
                                x.CollegeId == Id
                            ).Any();

                            if (!hascontact)
                            {
                                contactCollege.CollegeId = Id;
                                contactCollege.Name = ds.Tables[0].Rows[i][2].ToString();
                                contactCollege.Phone = ds.Tables[0].Rows[i][25].ToString();
                                contactCollege.Email = "";
                                contactCollege.CelPhone = "";

                                _contactRepository.Insert(contactCollege);
                            }
                            else
                            {
                                contactCollege.CollegeId = Id;
                                contactCollege.Name = ds.Tables[0].Rows[i][2].ToString();
                                contactCollege.Phone = ds.Tables[0].Rows[i][25].ToString();
                                contactCollege.Email = "";
                                contactCollege.CelPhone = "";

                                _contactRepository.Update(contactCollege);
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
