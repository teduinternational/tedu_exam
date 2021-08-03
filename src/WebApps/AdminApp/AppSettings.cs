using System;
namespace AdminApp
{
    public class AppSettings
    {
        public string BackendUrl { set; get; }
        public string DateTimeFormat { set; get; }
        public IdentityServerConfig IdentityServerConfig { set; get; }
    }

    public class IdentityServerConfig
    {
        public string IdentityServerUrl { set; get; }
        public string ClientId { set; get; }
        public string ClientSecret { set; get; }
    }
}
