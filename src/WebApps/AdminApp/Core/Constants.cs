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
        public const string Login = "/auth/login";
        public const string Dashboard = "/personal/dashboard";
        public const string Categories = "/app/categories";
        public const string Questions = "/app/questions";
        public const string Exams = "/app/exams";
    }

    public class DialogMode
    {
        public const string Edit = "Edit";
        public const string Add = "Add";
    }
}
