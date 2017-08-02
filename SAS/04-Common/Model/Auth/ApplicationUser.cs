using Common;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Model.Domain;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Model.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }

        public byte[] Imagen { get; set; }

        public int InstitucionId { get; set; }
        public Institucion Institucion { get; set; }

        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            userIdentity = await CreateUserClaims(userIdentity, manager, userIdentity.GetUserId());

            // Add custom user claims here
            return userIdentity;
        }

        // Create additional parameters to persist on the cookie
        public async static Task<ClaimsIdentity> CreateUserClaims(
            ClaimsIdentity identity,
            UserManager<ApplicationUser> manager,
            string userId
        )
        { 
            // Current User
            var currentUser = await manager.FindByIdAsync(userId);

            // Your User Data
            var jUser = JsonConvert.SerializeObject(new CurrentUser
            {
                UserId = currentUser.Id,
                Name = currentUser.Email,
                UserName = currentUser.Email,
            });

            identity.AddClaim(new Claim(ClaimTypes.UserData, jUser));

            return await Task.FromResult(identity);
        }

    }
}
