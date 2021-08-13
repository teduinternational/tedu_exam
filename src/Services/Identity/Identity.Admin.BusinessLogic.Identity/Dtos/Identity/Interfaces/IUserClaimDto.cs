namespace Identity.Admin.BusinessLogic.Identity.Dtos.Identity.Interfaces
{
    public interface IUserClaimDto : IBaseUserClaimDto
    {
        string ClaimType { get; set; }
        string ClaimValue { get; set; }
    }
}
