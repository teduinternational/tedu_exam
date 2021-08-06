using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApp.Core
{
    public class KeyConstants
    {
        public const string AccessToken = "AccessToken";
        public const string RefreshToken = "RefreshToken";
    }

    public class UrlConstants
    {
        public const string Login = "/pages/authentication/login";
        public const string Dashboard = "/personal/dashboard";
    }
}
