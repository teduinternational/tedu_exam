using Skoruba.AuditLogging.Events;

namespace Identity.BusinessLogic.Identity.Events.Identity
{
    public class UserClaimsSavedEvent<TUserClaimsDto> : AuditEvent
    {
        public TUserClaimsDto Claims { get; set; }

        public UserClaimsSavedEvent(TUserClaimsDto claims)
        {
            Claims = claims;
        }
    }
}