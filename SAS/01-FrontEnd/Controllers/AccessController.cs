using Common;
using FrontEnd.App_Start;
using FrontEnd.ViewModels;
using Model.Domain;
using Service;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class AccessController : Controller
    {
        private ISystemAccessService _systemAccessService = DependecyFactory.GetInstance<ISystemAccessService>();


    #region access

        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetAccess(int id)
        {
            return Json(
                _systemAccessService.Get(id)
            );
        }

        [HttpPost]
        public JsonResult GetAllAccess(AnexGRID grid)
        {
            return Json(
                _systemAccessService.GetAll(grid)
            );
        }

        [HttpPost]
        public JsonResult DeleteAccess(int id)
        {
            return Json(
                _systemAccessService.Delete(id)
            );
        }

        [HttpPost]
        public JsonResult AccessSave(SystemAccess model)
        {
            var rh = new ResponseHelper();

            if (!ModelState.IsValid)
            {
                var validations = ModelState.GetErrors();
                rh.SetValidations(validations);
            }
            else
            {
                rh = _systemAccessService.InsertOrUpdate(model);
                if (rh.Response)
                {
                    rh.Href = "self";
                }
            }

            return Json(rh);
        }

        [HttpPost]
        public JsonResult ChangeStatusByAccess(int id, Enums.StatusAccess status)
        {
            return Json(
                _systemAccessService.ChangeStatus(id, status)
            );
        }

        #endregion

    #region add acccess per rol

        [Route("Access/{acronym}/Roles")]
        public ActionResult Roles(string acronym)
        {
            ViewBag.Acronym = acronym;
            return View();
        }

        [HttpPost]
        public JsonResult GetAllRole(AnexGRID grid, string acronym)
        {
            return Json(
                _systemAccessService.GetAllRoles(grid, acronym)
            );
        }


        [HttpPost]
        public JsonResult ChangeStatusByAccessRole(string id, int access, int institute, bool status)
        {
            return Json(
                _systemAccessService.ChangeActivation(id,access,institute,status)
            );
        }
        #endregion

        public  ActionResult Opss()
        {
            return View();
        }

    }

}