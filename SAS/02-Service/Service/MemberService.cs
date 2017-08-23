using Common;
using Model.Auth;
using Model.Domain;
using NLog;
using Persistence.DbContextScope;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IMemberService
    {
        ResponseHelper InsertOrUpdate(Member model);
        AnexGRIDResponde GetAll(AnexGRID grid);
        IEnumerable<Member> GetAll();
        Member Get(int id);
        ResponseHelper Delete(string id);
    }

    public class MemberService : IMemberService
    {
        private readonly ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Member> _memberRepository;

        public MemberService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<Member> memberRepository
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _memberRepository = memberRepository;
        }

        public ResponseHelper InsertOrUpdate(Member model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    if (model.UserId != null)
                    {
                        var originalmember = _memberRepository.Single(x => x.UserId == model.UserId);

                        originalmember.Name = model.Name;
                        originalmember.LastName = model.LastName;

                        _memberRepository.Update(originalmember);
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

            //try
            //{
            //    using (var ctx = _dbContextScopeFactory.CreateReadOnly())
            //    {
            //        var access = ctx.GetEntity<SystemAccess>();
            //        var roles = ctx.GetEntity<ApplicationRole>();
            //        var accessRol = ctx.GetEntity<SystemAccessRoles>();

            //        var queryRoles = (
            //            from r in roles
            //            from ur in accessRol.Where(x => x.RoleId == r.Id)
            //            select new
            //            {
            //                AccessId = ur.Id,
            //                RoleId = ur.RoleId,
            //                Role = r.Name
            //            }
            //        ).AsQueryable();

            //        var query = (
            //                from a in access
            //                select new AccessForGridView
            //                {
            //                    Id = a.Id,
            //                    Action = a.ActionController,
            //                    Controller = a.Controller,
            //                    Description = a.DescriptionAccess,
            //                    Status = a.Status,
            //                    Roles = queryRoles.Where(x => x.AccessId == a.Id).Select(x => x.Role).ToList()
            //                }
            //            ).AsQueryable();

            //        if (grid.columna == "Controller")
            //        {
            //            query = grid.columna_orden == "ASC" ? query.OrderBy(x => x.Controller)
            //                                                : query.OrderByDescending(x => x.Controller);
            //        }

            //        foreach (var f in grid.filtros)
            //        {
            //            if (f.columna == "Controller")
            //                query = query.Where(x => x.Controller.StartsWith(f.valor));
            //        }

            //        var data = query
            //                   .Skip(grid.pagina)
            //                   .Take(grid.limite)
            //                   .ToList();
            //        var total = query.Count();

            //        grid.SetData(data, total);
            //    }
            //}
            //catch (Exception e)
            //{
            //    logger.Error(e.Message);
            //}

            return grid.responde();
        }

        public IEnumerable<Member> GetAll()
        {
            var result = new List<Member>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _memberRepository.GetAll().OrderBy(x => x.Name).ToList();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public Member Get(int id)
        {
            var result = new Member();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _memberRepository.SingleOrDefault(x => x.MemberId == id);
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
                    var originalMember = _memberRepository.Single(x => x.UserId == id);
                    _memberRepository.Delete(originalMember);

                        result.SetResponse(true);


                    ctx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                result.SetResponse(false, "Esta Acceso no puede ser eliminado debido a que tiene roles asignados.");
                    
            }

            return result;
        }

    }
}
