using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalApp.Core;

namespace PortalApp.Pages.Auth
{
    public class LoginModel : PageModel
    {
        public async Task OnGetAsync()
        {
            await HttpContext.ChallengeAsync(AuthenticationConsts.OidcAuthenticationScheme, new AuthenticationProperties
            {
                RedirectUri = "/"
            });
        }
    }
}
