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
    public interface IMunicipioService
    {
        IEnumerable<Municipio> GetAll();
        Municipio Detail(int id);
        ResponseHelper InsertOrUpdate(Municipio model);
        ResponseHelper Delete(int id);
    }

    public class MunicipioService : IMunicipioService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Municipio> _municipioRepository;

        public MunicipioService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<Municipio> municipioRepository
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _municipioRepository = municipioRepository;
        }

        public IEnumerable<Municipio> GetAll()
        {
            var result = new List<Municipio>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _municipioRepository
                             .GetAll(x => x.Localidades,
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

        public Municipio Detail(int id)
        {
            var result = new Municipio();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    result = _municipioRepository.SingleOrDefault(x => x.MunicipioId == id);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public ResponseHelper InsertOrUpdate(Municipio model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    if (model.MunicipioId == 0)
                    {
                        _municipioRepository.Insert(model);
                    }
                    else
                    {
                        _municipioRepository.Update(model);
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
                    var model = _municipioRepository.SingleOrDefault(x => x.MunicipioId == id);
                    _municipioRepository.Delete(model);

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
