using Agronomous.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Agronomous
{
    public class user : IdentityUser
    {
        public string plantGuid { get; set; }
    }
    public class PlantClaimsPrincipalFactory : UserClaimsPrincipalFactory<user, IdentityRole>
    {
        public PlantClaimsPrincipalFactory(
            UserManager<user> _userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor
            ) : base(_userManager,roleManager,optionsAccessor)
        {
        }
        public async override Task<ClaimsPrincipal> CreateAsync(user user)
        {
            var principal = await base.CreateAsync(user);
            if (!(user.plantGuid.Equals(null)))
            {
                ((ClaimsIdentity)principal.Identity).AddClaim(new Claim(ClaimTypes.Hash, user.plantGuid));
            }
            Console.WriteLine("Done");
            return principal;
        }
        
    }
    public static class IdentityExtensions
    {

        public static string GardenGuid(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("plantGuid");//((ClaimsIdentity)identity).FindFirst(ClaimTypes.Hash);
            //return (claim != null) ? claim.Value : string.Empty;
            return claim.Value;
        }
        public static Guid editGardenGuid(this IPrincipal currentPrincipal, AgronomousContext db)
        {
            Guid gardenGuid = Guid.NewGuid();
            var identity = currentPrincipal.Identity as ClaimsIdentity;
            if (identity == null)
            {
                return new Guid();
            }
            var existingClaim = identity.FindFirst(ClaimTypes.Hash);
            if (existingClaim != null)
            {
                identity.RemoveClaim(existingClaim);
            }
            identity.AddClaim(new Claim(ClaimTypes.Hash, gardenGuid.ToString()));

            return gardenGuid;
        }
    }
}
