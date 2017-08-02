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
    public interface IBeneficiarioService
    {
        IEnumerable<Beneficiario> GetAll();
        Beneficiario Detail(int id);
        ResponseHelper InsertOrUpdate(Beneficiario model);
        ResponseHelper Delete(int id);
    }

    public class BeneficiarioService : IBeneficiarioService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Beneficiario> _beneficiarioRepository;

        public BeneficiarioService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<Beneficiario> beneficiarioRepository
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _beneficiarioRepository = beneficiarioRepository;
        }

        public IEnumerable<Beneficiario> GetAll()
        {
            var result = new List<Beneficiario>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _beneficiarioRepository
                             .GetAll(x => x.Localidad,
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

        public Beneficiario Detail(int id)
        {
            var result = new Beneficiario();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    result = _beneficiarioRepository.SingleOrDefault(x => x.BeneficiarioId == id);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public ResponseHelper InsertOrUpdate(Beneficiario model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    if (model.BeneficiarioId == 0)
                    {
                        _beneficiarioRepository.Insert(model);
                    }
                    else
                    {
                        _beneficiarioRepository.Update(model);
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
                    var model = _beneficiarioRepository.SingleOrDefault(x => x.BeneficiarioId == id);
                    _beneficiarioRepository.Delete(model);

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