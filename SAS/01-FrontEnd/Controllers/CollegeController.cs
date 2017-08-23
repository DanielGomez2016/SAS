using Common;
using FrontEnd.App_Start;
using Model.Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class CollegeController : Controller
    {

        private ICollegeService _collegeService = DependecyFactory.GetInstance<ICollegeService>();

        // GET: College
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetCollege(int id)
        {
            return Json(
                _collegeService.Get(id)
            );
        }

        [HttpPost]
        public JsonResult GetAllCollege(AnexGRID grid)
        {
            return Json(
                _collegeService.GetAll(grid)
            );
        }

        [HttpPost]
        public JsonResult CollegeSave(College model)
        {
            var rh = new ResponseHelper();

            if (!ModelState.IsValid)
            {
                var validations = ModelState.GetErrors();
                rh.SetValidations(validations);
            }
            else
            {
                rh = _collegeService.InsertOrUpdate(model);
                if (rh.Response)
                {
                    rh.Href = "self";
                }
            }

            return Json(rh);
        }

        [HttpPost]
        public JsonResult CollegeSaveFile(HttpPostedFileBase file)
        {
            var rh = new ResponseHelper();

            if (!ModelState.IsValid)
            {
                var validations = ModelState.GetErrors();
                rh.SetValidations(validations);
            }
            else
            {
                rh = _collegeService.AddFile(file);
                if (rh.Response)
                {
                    rh.Href = "self";
                }
            }

            return Json(rh);
        }
    }
}