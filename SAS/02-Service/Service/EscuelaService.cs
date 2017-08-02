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
    public interface IEscuelaService
    {
        IEnumerable<Escuela> GetAll();
        Escuela Detail(int id);
        ResponseHelper InsertOrUpdate(Escuela model);
        ResponseHelper Delete(int id);
    }

    public class EscuelaService : IEscuelaService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Escuela> _escuelaRepository;

        public EscuelaService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<Escuela> escuelaRepository
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _escuelaRepository = escuelaRepository;
        }

        public IEnumerable<Escuela> GetAll()
        {
            var result = new List<Escuela>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _escuelaRepository
                             .GetAll(x => x.Contactos,
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

        public Escuela Detail(int id)
        {
            var result = new Escuela();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    result = _escuelaRepository.SingleOrDefault(x => x.EscuelaId == id);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public ResponseHelper InsertOrUpdate(Escuela model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    if (model.EscuelaId == 0)
                    {
                        _escuelaRepository.Insert(model);
                    }
                    else
                    {
                        _escuelaRepository.Update(model);
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
                    var model = _escuelaRepository.SingleOrDefault(x => x.EscuelaId == id);
                    _escuelaRepository.Delete(model);

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
