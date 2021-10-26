using Identity.Shared.Configuration.Configuration.Identity;
using Identity.STS.Identity.Configuration.Interfaces;

namespace Identity.STS.Identity.Configuration
{
    public class RootConfiguration : IRootConfiguration
    {      
        public AdminConfiguration AdminConfiguration { get; } = new AdminConfiguration();
        public RegisterConfiguration RegisterConfiguration { get; } = new RegisterConfiguration();
    }
}