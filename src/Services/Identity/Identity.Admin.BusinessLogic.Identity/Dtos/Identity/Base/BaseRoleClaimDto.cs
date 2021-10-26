using Identity.Admin.BusinessLogic.Identity.Dtos.Identity.Interfaces;

namespace Identity.Admin.BusinessLogic.Identity.Dtos.Identity.Base
{
    public class BaseRoleClaimDto<TRoleId> : IBaseRoleClaimDto
    {
        public int ClaimId { get; set; }

        public TRoleId RoleId { get; set; }

        object IBaseRoleClaimDto.RoleId => RoleId;
    }
}