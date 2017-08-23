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
    public interface ISystemAccessService
    {
        ResponseHelper InsertOrUpdate(SystemAccess model);
        AnexGRIDResponde GetAll(AnexGRID grid);
        IEnumerable<SystemAccess> GetAll();
        SystemAccess Get(int id);
        ResponseHelper Delete(int id);
        ResponseHelper ChangeStatus(int id, Enums.StatusAccess status);
        AnexGRIDResponde GetAllRoles(AnexGRID grid, string acronym);
        ResponseHelper ChangeActivation(string id, int access, int institute, bool status);
        ResponseHelper WhitAccess();
    }

    public class SystemAccessService : ISystemAccessService
    {
        private readonly ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<SystemAccess> _systemAccessRepository;
        private readonly IRepository<SystemAccessRoles> _systemAccessRolesRepository;

        public SystemAccessService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<SystemAccess> systemAccessRepository,
            IRepository<SystemAccessRoles> systemAccessRolesRepository
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _systemAccessRepository = systemAccessRepository;
            _systemAccessRolesRepository = systemAccessRolesRepository;
        }

        public ResponseHelper InsertOrUpdate(SystemAccess model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    if (model.Id > 0)
                    {
                        var originalAccess = _systemAccessRepository.Single(x => x.Id == model.Id);

                        originalAccess.Controller = model.Controller;
                        originalAccess.ActionController = model.ActionController;
                        originalAccess.DescriptionAccess = model.DescriptionAccess;

                        _systemAccessRepository.Update(originalAccess);
                    }
                    else
                    {
                        // Después de insertar el campo Id ya tiene ID
                        _systemAccessRepository.Insert(model);
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
                    var access = ctx.GetEntity<SystemAccess>();
                    var roles = ctx.GetEntity<ApplicationRole>();
                    var accessRol = ctx.GetEntity<SystemAccessRoles>();

                    var queryRoles = (
                        from r in roles
                        from ur in accessRol.Where(x => x.RoleId == r.Id)
                        select new
                        {
                            AccessId = ur.Id,
                            RoleId = ur.RoleId,
                            Role = r.Name
                        }
                    ).AsQueryable();

                    var query = (
                            from a in access
                            select new AccessForGridView
                            {
                                Id = a.Id,
                                Action = a.ActionController,
                                Controller = a.Controller,
                                Description = a.DescriptionAccess,
                                Status = a.Status,
                                Roles = queryRoles.Where(x => x.AccessId == a.Id).Select(x => x.Role).ToList()
                            }
                        ).AsQueryable();

                    if(grid.columna == "Controller")
                    {
                        query = grid.columna_orden == "ASC" ? query.OrderBy(x => x.Controller)
                                                            : query.OrderByDescending(x => x.Controller);
                    }

                    foreach (var f in grid.filtros)
                    {
                        if (f.columna == "Controller")
                            query = query.Where(x => x.Controller.StartsWith(f.valor));
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

        public IEnumerable<SystemAccess> GetAll()
        {
            var result = new List<SystemAccess>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _systemAccessRepository.GetAll().OrderBy(x => x.Controller).ToList();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public SystemAccess Get(int id)
        {
            var result = new SystemAccess();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _systemAccessRepository.SingleOrDefault(x => x.Id == id);
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
                    var hasRoles = _systemAccessRepository.Find(x =>
                        x.Id == id
                    ).Any();

                    if (!hasRoles)
                    {
                        var originalAccess = _systemAccessRepository.Single(x => x.Id == id);
                        _systemAccessRepository.Delete(originalAccess);

                        result.SetResponse(true);
                    }
                    else
                    {
                        result.SetResponse(false, "Esta Acceso no puede ser eliminado debido a que tiene roles asignados.");
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

        public ResponseHelper ChangeStatus(int id, Enums.StatusAccess status)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var originalEntry = _systemAccessRepository.Single(x => x.Id == id);
                    originalEntry.Status = status;

                    _systemAccessRepository.Update(originalEntry);

                    ctx.SaveChanges();
                    rh.SetResponse(true);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, e.Message);
            }

            return rh;
        }

        public AnexGRIDResponde GetAllRoles(AnexGRID grid, string acronym)
        {
            grid.Inicializar();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    var institutions = ctx.GetEntity<Institution>();
                    var access = ctx.GetEntity<SystemAccess>();
                    var accessRol = ctx.GetEntity<SystemAccessRoles>();
                    var roles = ctx.GetEntity<ApplicationRole>();
                    var userRole = ctx.GetEntity<ApplicationUserRole>();
                    var users = ctx.GetEntity<ApplicationUser>();


                    var queryInstitute = institutions.Single(x => x.Acronym.Contains(acronym)).InstitutionId;

                    var queryAccess = (
                        from a in access
                        select new
                        {
                            AccessId = a.Id,
                            NameAccess = a.Controller,
                        }
                        ).AsQueryable();

                    var queryAccessRol = (
                        from ar in accessRol
                        from a in access
                                   .Where(x => x.Id == ar.Id && ar.InstitutionId == queryInstitute)
                                   .OrderBy(x => x.Controller)
                                    select new
                                    {
                                        AccessId = a.Id,
                                        NameAccess = a.Controller,
                                        RoleId = ar.RoleId,
                                        AccessStatus = ar.Access
                                    }
                        ).AsQueryable();

                    var queryUsers = (
                        from u in users
                        from ur in userRole.Where(x => x.UserId == u.Id)
                        select new
                        {
                            RoleId = ur.RoleId
                        }
                    ).AsQueryable();

                    var query = (
                            from r in roles
                            select new RolesForGridView
                            {
                                Id = r.Id,
                                Name = r.Name,
                                bodyAccess = queryAccess.Select(x => new BodyAccess {
                                    AccessId = x.AccessId,
                                    AccessName = x.NameAccess,
                                    Status = queryAccessRol
                                             .FirstOrDefault(y => y.RoleId == r.Id && y.AccessId == x.AccessId).AccessStatus != false &&
                                             queryAccessRol
                                             .FirstOrDefault(y => y.RoleId == r.Id && y.AccessId == x.AccessId) != null ? true : false
                                }).ToList(),
                                TotalUsers = queryUsers.Where(x => x.RoleId == r.Id).Count(),
                                InstituteId = queryInstitute
                            }
                        ).AsQueryable();

                    if (grid.columna == "Name")
                    {
                        query = grid.columna_orden == "ASC" ? query.OrderBy(x => x.Name)
                                                            : query.OrderByDescending(x => x.Name);
                    }

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

        public ResponseHelper ChangeActivation(string id, int access, int institute, bool status)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var accessRol = ctx.GetEntity<SystemAccessRoles>();
                    var originalEntry = new SystemAccessRoles();

                    originalEntry = accessRol.FirstOrDefault(x => x.Id == access && x.RoleId == id && x.InstitutionId == institute);

                    if (originalEntry != null)
                    {
                        if (status)
                        {
                            originalEntry.Access = false;
                        }
                        else
                        {
                            originalEntry.Access = true;
                        }
                        _systemAccessRolesRepository.Update(originalEntry);
                    }

                    if (originalEntry == null)
                    {
                        originalEntry = new SystemAccessRoles
                        {
                            RoleId = id,
                            Id = access,
                            InstitutionId = institute,
                            Access = status == false ? true : false
                        };


                        _systemAccessRolesRepository.Insert(originalEntry);
                    }

                    ctx.SaveChanges();
                    rh.SetResponse(true);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, e.Message);
            }

            return rh;
        }

        public ResponseHelper WhitAccess()
        {
            var result = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var user = CurrentUserHelper.Get.UserId;
                    var userRole = ctx.GetEntity<ApplicationUserRole>();
                    var role = ctx.GetEntity<ApplicationRole>();
                    var accessRole = ctx.GetEntity<SystemAccessRoles>();
                    var access = ctx.GetEntity<SystemAccess>();


                    var queryRolesforUser = (
                        from ur in userRole
                        from r in role.Where(x => x.Id == ur.RoleId && ur.UserId == user)
                        select new
                        {
                            RoleId = r.Id,
                            Name = r.Name,
                            User = ur.UserId,
                        }
                        ).ToList();


                    var queryAccessforRole = (
                        from ar in accessRole
                        from a in access.Where(x => x.Id == ar.Id)
                        select new
                        {
                            AccessId = a.Id,
                            Name = a.Controller,
                            RoleId = ar.RoleId
                        }
                        ).ToList();

                    var hasRoles = (
                        from r in queryRolesforUser
                        from a in queryAccessforRole.Where(x => x.RoleId == r.RoleId)
                        select new
                        {
                            AccessId = a.AccessId,
                            RoleId = r.RoleId,
                            UserId = r.User
                        }
                        ).Any();

                    if (hasRoles)
                    {
                        result.SetResponse(true);
                    }
                    else
                    {
                        result.SetResponse(false);
                    }
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
