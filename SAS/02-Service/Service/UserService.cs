using Auth.Service;
using Common;
using Microsoft.AspNet.Identity;
using Model.Auth;
using Model.Custom;
using Model.Domain;
using NLog;
using Persistence.DbContextScope;
using Persistence.DbContextScope.Extensions;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Service
{
    public interface IUserService
    {
        IEnumerable<UserForGridView> GetAll();
        ResponseHelper Update(ApplicationUser model);
        ResponseHelper Delete(string id);
        AnexGRIDResponde GetAll(AnexGRID grid);
        UserperMember Get(string id);
    }

    public class UserService : IUserService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<ApplicationUser> _applicationUserRepository;

        public UserService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<ApplicationUser> applicationUserRepository
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _applicationUserRepository = applicationUserRepository;
        }

        public IEnumerable<UserForGridView> GetAll()
        {
            var result = new List<UserForGridView>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    var abc = _applicationUserRepository.GetAll().ToList();

                    var users = ctx.GetEntity<ApplicationUser>();
                    var roles = ctx.GetEntity<ApplicationRole>();
                    var usersPerRoles = ctx.GetEntity<ApplicationUserRole>();

                    var queryUsersPerRoles = (
                        from upr in usersPerRoles
                        from r in roles.Where(x => x.Id == upr.RoleId)
                        select new
                        {
                            upr.UserId,
                            r.Name
                        }
                    ).AsQueryable();

                    result = (
                        from u in users
                        select new UserForGridView
                        {
                            Id = u.Id,
                            Email = u.Email,
                            Roles = queryUsersPerRoles.Where(x =>
                                x.UserId == u.Id
                            ).Select(x => x.Name).ToList()
                        }
                    ).ToList();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public ResponseHelper Update(ApplicationUser model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var originalModel = _applicationUserRepository.Single(x => x.Id == model.Id);
                    originalModel.Email = model.Email;
                    originalModel.UserName = model.Email;

                    _applicationUserRepository.Update(originalModel);
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

        public AnexGRIDResponde GetAll(AnexGRID grid)
        {
            grid.Inicializar();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    var users = ctx.GetEntity<ApplicationUser>();
                    var roles = ctx.GetEntity<ApplicationRole>();
                    var member = ctx.GetEntity<Member>();
                    var userRol = ctx.GetEntity<ApplicationUserRole>();

                    var queryRoles = (
                        from r in roles
                        from ur in userRol.Where(x => x.RoleId == r.Id)
                        select new
                        {
                            RoleId = ur.RoleId,
                            Role = r.Name,
                            UserId = ur.UserId
                        }
                    ).AsQueryable();

                    var query = (
                            from u in users
                            from m in member.Where(x => x.UserId == u.Id && x.Deleted != true)
                            select new UserForGridView
                            {
                                Id = u.Id,
                                Idm = m.MemberId,
                                Email = u.Email,
                                Name = m.Name +" "+ m.LastName,
                                Roles = queryRoles.Where(x => x.UserId == u.Id).Select(x => x.Role).ToList()
                            }
                        ).AsQueryable();

                    if (grid.columna == "Email")
                    {
                        query = grid.columna_orden == "ASC" ? query.OrderBy(x => x.Email)
                                                            : query.OrderByDescending(x => x.Email);
                    }

                    foreach (var f in grid.filtros)
                    {
                        if (f.columna == "Email")
                            query = query.Where(x => x.Email.StartsWith(f.valor));
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

        public UserperMember Get(string id)
        {
            var result = new UserperMember();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    var users = ctx.GetEntity<ApplicationUser>();
                    var member = ctx.GetEntity<Member>();



                    var queryUser = users.FirstOrDefault(x => x.Id == id);
                    var queryMember = member.FirstOrDefault(x => x.UserId == id);

                    result = new UserperMember
                    {
                        Id = queryMember.UserId,
                        Name = queryMember.Name,
                        LastName = queryMember.LastName,
                        Email = queryUser.Email
                    };

                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public ResponseHelper Delete(string id)
        {
            var result = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var hasRoles = _applicationUserRepository.Find(x =>
                        x.Id == id
                        && x.Roles.Any()
                    ).Any();

                    if (hasRoles)
                    {
                        var originalUser = _applicationUserRepository.Single(x => x.Id == id);
                        _applicationUserRepository.Delete(originalUser);

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

    }
}
