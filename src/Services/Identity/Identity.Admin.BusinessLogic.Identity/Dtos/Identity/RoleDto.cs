using System.ComponentModel.DataAnnotations;
using Identity.Admin.BusinessLogic.Identity.Dtos.Identity.Base;
using Identity.Admin.BusinessLogic.Identity.Dtos.Identity.Interfaces;

namespace Identity.Admin.BusinessLogic.Identity.Dtos.Identity
{
    public class RoleDto<TKey> : BaseRoleDto<TKey>, IRoleDto
    {      
        [Required]
        public string Name { get; set; }
    }
}