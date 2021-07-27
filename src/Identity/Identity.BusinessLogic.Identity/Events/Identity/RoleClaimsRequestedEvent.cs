using Skoruba.AuditLogging.Events;

namespace Identity.BusinessLogic.Identity.Events.Identity
{
    public class RoleClaimsRequestedEvent<TRoleClaimsDto> : AuditEvent
    {
        public TRoleClaimsDto RoleClaims { get; set; }

        public RoleClaimsRequestedEvent(TRoleClaimsDto roleClaims)
        {
            RoleClaims = roleClaims;
        }
    }
}