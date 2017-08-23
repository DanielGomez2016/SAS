using Common;
using FrontEnd.App_Start;
using FrontEnd.Filters;
using Model.Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    [Authorize, Access]
    public class InstitutionController : Controller
    {
        private IInstitutionService _institutionService = DependecyFactory.GetInstance<IInstitutionService>();

        // GET: Institution
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetInstitute(int id)
        {
            return Json(
                _institutionService.Get(id)
            );
        }

        [HttpPost]
        public JsonResult GetAllInstitute(AnexGRID grid)
        {
            return Json(
                _institutionService.GetAll(grid)
            );
        }

        [HttpPost]
        public JsonResult DeleteInstitution(int id)
        {
            return Json(
                _institutionService.Delete(id)
            );
        }

        [HttpPost]
        public JsonResult InstitutionSave(Institution model)
        {
            var rh = new ResponseHelper();

            if (!ModelState.IsValid)
            {
                var validations = ModelState.GetErrors();
                rh.SetValidations(validations);
            }
            else
            {
                rh = _institutionService.InsertOrUpdate(model);
                if (rh.Response)
                {
                    rh.Href = "self";
                }
            }

            return Json(rh);
        }

    }
}