using Auth.Service;
using Common;
using FrontEnd.App_Start;
using FrontEnd.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Model.Auth;
using Model.Domain;
using Service;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    //[Authorize]
    public class UsersController : Controller
    {
        private ApplicationRoleManager _roleManager
        {
            get
            {
                return HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
        }

        private ApplicationUserManager _userManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        private readonly IUserService _userService = DependecyFactory.GetInstance<IUserService>();
        private IMemberService _memberService = DependecyFactory.GetInstance<IMemberService>();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetAllUsers(AnexGRID grid)
        {
            return Json(
                _userService.GetAll(grid)
            );
        }

        [HttpPost]
        public JsonResult GetUser(string id)
        {
            return Json(
                _userService.Get(id)
            );
        }

        public async Task<ActionResult> Get(string id)
        {
            var model = await _userManager.FindByIdAsync(id);
            ViewBag.Roles = _roleManager.Roles.OrderBy(x => x.Name).ToList();

            return View(model);
        }

        [HttpPost]
        public JsonResult UserSave(UserBasicInformationViewModel model)
        {
            var rh = new ResponseHelper();

            if (!ModelState.IsValid)
            {
                var validations = ModelState.GetErrors();
                rh.SetValidations(validations);
            }
            else
            {
                var user = new ApplicationUser
                {
                    Id = model.Id,
                    UserName = model.Email,
                    Email = model.Email,
                };

                var member = new Member
                {
                    Name = model.Name,
                    LastName = model.Lastname,
                    UserId = model.Id,
                };

                rh = _userService.Update(user);
                if (rh.Response)
                {
                    rh = _memberService.InsertOrUpdate(member);
                    if (rh.Response)
                    {
                        rh.Href = "self";
                    }
                }
            }

            return Json(rh);
        }

        [HttpPost]
        public JsonResult DeleteUser(string id)
        {
            return Json(
                _memberService.Delete(id)
            );
        }

        public async Task<ActionResult> AddRole(ApplicationUserRole role)
        {
            if (!_userManager.IsInRoleAsync(role.UserId, role.RoleId).Result)
            {
                var result = await _userManager.AddToRoleAsync(role.UserId, role.RoleId);

                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First());
                }
            }

            return RedirectToAction("Index");
        }
    }
}