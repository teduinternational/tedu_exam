namespace Identity.BusinessLogic.Identity.Dtos.Identity.Interfaces
{
    public interface IBaseUserClaimDto
    {
        int ClaimId { get; set; }
        object UserId { get; }
    }
}
