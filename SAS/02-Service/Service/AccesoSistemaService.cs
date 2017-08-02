using Common;
using Model.Auth;
using Model.Custom;
using Model.Domain;
using NLog;
using Persistence.DbContextScope;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public interface IAccesoSistemaService
    {
        IEnumerable<AccesoSistema> GetAll();
        AccesoSistema Get(int id);
        ResponseHelper InsertOrUpdate(AccesoSistema model);
        ResponseHelper Delete(int id);
    }

    public class AccesoSistemaService : IAccesoSistemaService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<AccesoSistema> _accesoSistemaRepository;
        private readonly IRepository<ApplicationUser> _applicationUser;
        private readonly IRepository<ApplicationRole> _applicationRole;

        public AccesoSistemaService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<AccesoSistema> accesoSistemaRepository,
            IRepository<ApplicationUser> applicationUser,
            IRepository<ApplicationRole> applicationRole
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _accesoSistemaRepository = accesoSistemaRepository;
            _applicationUser = applicationUser;
            _applicationRole = applicationRole;
        }

        public IEnumerable<AccesoSistema> GetAll()
        {
            var result = new List<AccesoSistema>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _accesoSistemaRepository
                            .GetAll(x => x.AccesosRol,
                                    x => x.CreatedUser)
                            .ToList();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public AccesoSistema Get(int id)
        {
            var result = new AccesoSistema();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    result = _accesoSistemaRepository.SingleOrDefault(x => x.AccesoSistemaId == id);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public ResponseHelper InsertOrUpdate(AccesoSistema model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    if (model.AccesoSistemaId == 0)
                    {
                        _accesoSistemaRepository.Insert(model);
                    }
                    else
                    {
                        _accesoSistemaRepository.Update(model);
                    }

                    ctx.SaveChanges();
                    rh.SetResponse(true);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return rh;
        }

        public ResponseHelper Delete(int id)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var model = _accesoSistemaRepository.SingleOrDefault(x => x.AccesoSistemaId == id);
                    _accesoSistemaRepository.Delete(model);

                    ctx.SaveChanges();
                    rh.SetResponse(true);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return rh;
        }
    }
}
