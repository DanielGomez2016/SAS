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
    public interface ILocalidadService
    {
        IEnumerable<Localidad> GetAll();
        Localidad Detail(int id);
        ResponseHelper InsertOrUpdate(Localidad model);
        ResponseHelper Delete(int id);
    }

    public class LocalidadService : ILocalidadService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Localidad> _localidadRepository;

        public LocalidadService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<Localidad> localidadRepository
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _localidadRepository = localidadRepository;
        }

        public IEnumerable<Localidad> GetAll()
        {
            var result = new List<Localidad>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _localidadRepository
                             .GetAll(x => x.Escuelas,
                                     x => x.CreatedUser,
                                     x => x.Municipio)
                             .ToList();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public Localidad Detail(int id)
        {
            var result = new Localidad();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    result = _localidadRepository.SingleOrDefault(x => x.LocalidadId == id);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public ResponseHelper InsertOrUpdate(Localidad model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    if (model.LocalidadId == 0)
                    {
                        _localidadRepository.Insert(model);
                    }
                    else
                    {
                        _localidadRepository.Update(model);
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
                    var model = _localidadRepository.SingleOrDefault(x => x.LocalidadId == id);
                    _localidadRepository.Delete(model);

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
