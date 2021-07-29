using Microsoft.AspNetCore.Mvc;
using Identity.Admin.Configuration.Interfaces;

namespace Identity.Admin.ViewComponents
{
    public class IdentityServerLinkViewComponent : ViewComponent
    {
        private readonly IRootConfiguration _configuration;

        public IdentityServerLinkViewComponent(IRootConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IViewComponentResult Invoke()
        {
            var identityServerUrl = _configuration.AdminConfiguration.IdentityServerBaseUrl;

            return View(model: identityServerUrl);
        }
    }
}
