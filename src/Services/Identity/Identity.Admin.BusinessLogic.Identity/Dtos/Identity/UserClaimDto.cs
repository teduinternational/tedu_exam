using System.ComponentModel.DataAnnotations;
using Identity.Admin.BusinessLogic.Identity.Dtos.Identity.Base;
using Identity.Admin.BusinessLogic.Identity.Dtos.Identity.Interfaces;

namespace Identity.Admin.BusinessLogic.Identity.Dtos.Identity
{
    public class UserClaimDto<TKey> : BaseUserClaimDto<TKey>, IUserClaimDto
    {
        [Required]
        public string ClaimType { get; set; }

        [Required]
        public string ClaimValue { get; set; }
    }
}