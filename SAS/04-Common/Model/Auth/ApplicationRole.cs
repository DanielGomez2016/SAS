using Microsoft.AspNet.Identity.EntityFramework;
using Model.Domain;
using System.Collections.Generic;

namespace Model.Auth
{
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; }

    }
}
