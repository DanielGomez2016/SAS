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
    public interface IAccesoSistemaRolService
    {
        ResponseHelper Insert(AccesoSistemaRol model);
    }

    public class AccesoSistemaRolService : IAccesoSistemaRolService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<AccesoSistemaRol> _accesoSistemaRolRepository;

        public AccesoSistemaRolService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<AccesoSistemaRol> accesoSistemaRolRepository
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _accesoSistemaRolRepository = accesoSistemaRolRepository;
        }

        public ResponseHelper Insert(AccesoSistemaRol model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    _accesoSistemaRolRepository.Insert(model);

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
