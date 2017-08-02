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
    public interface IInstitucionService
    {
        IEnumerable<Institucion> GetAll();
        Institucion Detail(int id);
        ResponseHelper InsertOrUpdate(Institucion model);
        ResponseHelper Delete(int id);
    }

    public class InstitucionService : IInstitucionService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Institucion> _institucionRepository;

        public InstitucionService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<Institucion> institucionRepository
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _institucionRepository = institucionRepository;
        }

        public IEnumerable<Institucion> GetAll()
        {
            var result = new List<Institucion>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _institucionRepository
                             .GetAll(x => x.Departamentos, x => x.CreatedUser)
                             .ToList();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public Institucion Detail(int id)
        {
            var result = new Institucion();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    result = _institucionRepository.SingleOrDefault(x => x.InstitucionId == id);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public ResponseHelper InsertOrUpdate(Institucion model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    if (model.InstitucionId == 0)
                    {
                        _institucionRepository.Insert(model);
                    }
                    else
                    {
                        _institucionRepository.Update(model);
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
                    var model = _institucionRepository.SingleOrDefault(x => x.InstitucionId == id);
                    _institucionRepository.Delete(model);

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
