using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalApp.Core
{
    public class UrlConstants
    {
        public const string Login = "/login.html";
        public const string ExamDetail = "/exam-details/{0}";
    }

    public class AuthenticationConsts
    {
        public const string SignInScheme = "cookie";
        public const string OidcAuthenticationScheme = "oidc";
    }
}
