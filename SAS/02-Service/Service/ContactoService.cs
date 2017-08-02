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
    public interface IContactoService
    {
        IEnumerable<Contacto> GetAll();
        Contacto Detail(int id);
        ResponseHelper InsertOrUpdate(Contacto model);
        ResponseHelper Delete(int id);
    }

    public class ContactoService : IContactoService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Contacto> _contactoRepository;

        public ContactoService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<Contacto> contactoRepository
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _contactoRepository = contactoRepository;
        }

        public IEnumerable<Contacto> GetAll()
        {
            var result = new List<Contacto>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _contactoRepository
                             .GetAll(x => x.Escuela, x => x.CreatedUser)
                             .ToList();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public Contacto Detail(int id)
        {
            var result = new Contacto();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    result = _contactoRepository.SingleOrDefault(x => x.ContactoId == id);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public ResponseHelper InsertOrUpdate(Contacto model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    if (model.ContactoId == 0)
                    {
                        _contactoRepository.Insert(model);
                    }
                    else
                    {
                        _contactoRepository.Update(model);
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
                    var model = _contactoRepository.SingleOrDefault(x => x.ContactoId == id);
                    _contactoRepository.Delete(model);

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
