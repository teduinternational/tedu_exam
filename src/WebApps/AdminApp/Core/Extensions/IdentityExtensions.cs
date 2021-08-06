using IdentityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AdminApp.Core.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            var claim = ((ClaimsIdentity)claimsPrincipal.Identity)
                .Claims
                .SingleOrDefault(x => x.Type == JwtClaimTypes.Subject);
            return claim.Value;
        }

        public static string GetFullName(this ClaimsPrincipal claimsPrincipal)
        {
            var firstName = ((ClaimsIdentity)claimsPrincipal.Identity)
                .Claims
                .SingleOrDefault(x => x.Type == JwtClaimTypes.GivenName);

            var lastName = ((ClaimsIdentity)claimsPrincipal.Identity)
                .Claims
                .SingleOrDefault(x => x.Type == JwtClaimTypes.FamilyName);

            return firstName?.Value + " " + lastName?.Value;
        }
    }
}
