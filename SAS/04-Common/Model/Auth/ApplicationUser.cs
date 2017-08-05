using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Model.Domain;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Model.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public byte[] BigFile { get; set; }
        public byte[] SmallFile { get; set; }

        public Institution Institution { get; set; }
        public int? InstitutionId { get; set; }

        public Department Department { get; set; }
        public int? DepartmentId { get; set; }
    }
}
