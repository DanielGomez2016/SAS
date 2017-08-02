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
    public interface IDepartamentoService
    {
        IEnumerable<Departamento> GetAll();
        Departamento Detail(int id);
        ResponseHelper InsertOrUpdate(Departamento model);
        ResponseHelper Delete(int id);
    }

    public class DepartamentoService : IDepartamentoService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Departamento> _departamentoRepository;

        public DepartamentoService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<Departamento> departamentoRepository
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _departamentoRepository = departamentoRepository;
        }

        public IEnumerable<Departamento> GetAll()
        {
            var result = new List<Departamento>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _departamentoRepository
                             .GetAll(x => x.Institucion,
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

        public Departamento Detail(int id)
        {
            var result = new Departamento();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    result = _departamentoRepository.SingleOrDefault(x => x.DepartamentoId == id);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public ResponseHelper InsertOrUpdate(Departamento model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    if (model.DepartamentoId == 0)
                    {
                        _departamentoRepository.Insert(model);
                    }
                    else
                    {
                        _departamentoRepository.Update(model);
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
                    var model = _departamentoRepository.SingleOrDefault(x => x.DepartamentoId == id);
                    _departamentoRepository.Delete(model);

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
