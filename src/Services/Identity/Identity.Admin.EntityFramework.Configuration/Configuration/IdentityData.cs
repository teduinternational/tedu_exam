using System.Collections.Generic;
using Identity.Admin.EntityFramework.Configuration.Configuration.Identity;

namespace Identity.Admin.EntityFramework.Configuration.Configuration
{
	public class IdentityData
    {
       public List<Role> Roles { get; set; }
       public List<User> Users { get; set; }
    }
}
