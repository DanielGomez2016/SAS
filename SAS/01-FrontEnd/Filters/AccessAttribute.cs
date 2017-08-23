using Common;
using Model.Domain;
using Persistence.Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Filters
{
    public class AccessAttribute : AuthorizeAttribute
    {
        private ISystemAccessService _systemAccessService = DependecyFactory.GetInstance<ISystemAccessService>();

        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (filterContext.HttpContext.Request.IsAuthenticated)
            {

                ResponseHelper access = _systemAccessService.WhitAccess();

                if (!access.Response)
                {
                    filterContext.Result = new RedirectResult("/Access/Opss");
                }

            }

        }
    }
}