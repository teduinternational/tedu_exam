﻿namespace Identity.Admin.BusinessLogic.Identity.Dtos.Identity.Interfaces
{
    public interface IBaseRoleClaimDto
    {
        int ClaimId { get; set; }
        object RoleId { get; }
    }
}
