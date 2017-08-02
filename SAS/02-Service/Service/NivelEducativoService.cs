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
    public interface INivelEducativoService
    {
        IEnumerable<NivelEducativo> GetAll();
        NivelEducativo Detail(int id);
        ResponseHelper InsertOrUpdate(NivelEducativo model);
        ResponseHelper Delete(int id);
    }

    public class NivelEducativoService : INivelEducativoService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<NivelEducativo> _nivelEducativoRepository;

        public NivelEducativoService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<NivelEducativo> nivelEducativoRepository
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _nivelEducativoRepository = nivelEducativoRepository;
        }

        public IEnumerable<NivelEducativo> GetAll()
        {
            var result = new List<NivelEducativo>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _nivelEducativoRepository
                             .GetAll(x => x.Escuelas, x => x.CreatedUser)
                             .ToList();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public NivelEducativo Detail(int id)
        {
            var result = new NivelEducativo();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    result = _nivelEducativoRepository.SingleOrDefault(x => x.NivelEducativoId == id);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public ResponseHelper InsertOrUpdate(NivelEducativo model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    if (model.NivelEducativoId == 0)
                    {
                        _nivelEducativoRepository.Insert(model);
                    }
                    else
                    {
                        _nivelEducativoRepository.Update(model);
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
                    var model = _nivelEducativoRepository.SingleOrDefault(x => x.NivelEducativoId == id);
                    _nivelEducativoRepository.Delete(model);

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
