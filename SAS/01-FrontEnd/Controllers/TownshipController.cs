using Common;
using FrontEnd.App_Start;
using Model.Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class TownshipController : Controller
    {

        private ITownshipService _townshipService = DependecyFactory.GetInstance<ITownshipService>();

        // GET: Township
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetTownship(int id)
        {
            return Json(
                _townshipService.Get(id)
            );
        }

        [HttpPost]
        public JsonResult GetAllTownship(AnexGRID grid)
        {
            return Json(
                _townshipService.GetAll(grid)
            );
        }

        [HttpPost]
        public JsonResult TownshipSave(Township model)
        {
            var rh = new ResponseHelper();

            if (!ModelState.IsValid)
            {
                var validations = ModelState.GetErrors();
                rh.SetValidations(validations);
            }
            else
            {
                rh = _townshipService.InsertOrUpdate(model);
                if (rh.Response)
                {
                    rh.Href = "self";
                }
            }

            return Json(rh);
        }

        [HttpPost]
        public JsonResult TownshipSaveFile(HttpPostedFileBase file)
        {
            var rh = new ResponseHelper();

            if (!ModelState.IsValid)
            {
                var validations = ModelState.GetErrors();
                rh.SetValidations(validations);
            }
            else
            {
                rh = _townshipService.AddFile(file);
                if (rh.Response)
                {
                    rh.Href = "self";
                }
            }

            return Json(rh);
        }
    }
}