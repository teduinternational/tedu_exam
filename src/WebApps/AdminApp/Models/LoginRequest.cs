using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApp.Models
{
    public class LoginRequest
    {
        public string UserName { set; get; }
        public string Password { set; get; }
    }
}
