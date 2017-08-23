using Common;
using Model.Auth;
using Model.Custom;
using Model.Domain;
using NLog;
using Persistence.DbContextScope;
using Persistence.DbContextScope.Extensions;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IInstitutionService
    {
        ResponseHelper InsertOrUpdate(Institution model);
        AnexGRIDResponde GetAll(AnexGRID grid);
        IEnumerable<Institution> GetAll();
        Institution Get(int id);
        ResponseHelper Delete(int id);
    }

    public class InstitutionService : IInstitutionService
    {
        private readonly ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Institution> _InstitutionRepository;
        private readonly IRepository<ApplicationUser> _applicationUserRepo;

        public InstitutionService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<Institution> InstitutionRepository,
            IRepository<ApplicationUser> applicationUserRepo
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _InstitutionRepository = InstitutionRepository;
            _applicationUserRepo = applicationUserRepo;
        }

        public ResponseHelper InsertOrUpdate(Institution model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    if (model.InstitutionId > 0)
                    {
                        var originalInstitution = _InstitutionRepository.Single(x => x.InstitutionId == model.InstitutionId);

                        originalInstitution.Name = model.Name;
                        originalInstitution.Acronym = model.Acronym;
                        originalInstitution.Manager = model.Manager;
                        originalInstitution.Description = model.Description;
                        originalInstitution.Phone = model.Phone;
                        originalInstitution.extension = model.extension;

                        _InstitutionRepository.Update(originalInstitution);
                    }
                    else
                    {
                        _InstitutionRepository.Insert(model);
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
                    var institution = ctx.GetEntity<Institution>();
                    var department = ctx.GetEntity<Department>();

                    var query = (
                            from i in institution
                            select new InstitutionForGridView
                            {
                                Id = i.InstitutionId,
                                Name = i.Name,
                                Acronym = i.Acronym,
                                Manager = i.Manager,
                                Phone = i.Phone + " ext. " + i.extension,
                                Departments = department.Where(x => x.InstitutionId == i.InstitutionId).Count(),
                                Users = 0,
                            }
                        ).AsQueryable();

                    //orden by
                    if (grid.columna == "Name")
                    {
                        query = grid.columna_orden == "ASC" ? query.OrderBy(x => x.Name)
                                                            : query.OrderByDescending(x => x.Name);
                    }

                    //filtros
                    foreach (var f in grid.filtros)
                    {
                        if (f.columna == "Name")
                            query = query.Where(x => x.Name.StartsWith(f.valor));
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

        public IEnumerable<Institution> GetAll()
        {
            var result = new List<Institution>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _InstitutionRepository.GetAll().OrderBy(x => x.Name).ToList();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public Institution Get(int id)
        {
            var result = new Institution();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _InstitutionRepository.SingleOrDefault(x => x.InstitutionId == id);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public ResponseHelper Delete(int id)
        {
            var result = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var hasDepto = _InstitutionRepository.Find(x =>
                        x.InstitutionId == id
                        && x.Deparments.Any()
                    ).Any();

                    if (!hasDepto)
                    {
                        var originalAccess = _InstitutionRepository.Single(x => x.InstitutionId == id);
                        _InstitutionRepository.Delete(originalAccess);

                        result.SetResponse(true);
                    }
                    else
                    {
                        result.SetResponse(false, "Esta Institucion no puede ser eliminado debido a que tiene departamentos asignados.");
                    }

                    ctx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

    }
}
