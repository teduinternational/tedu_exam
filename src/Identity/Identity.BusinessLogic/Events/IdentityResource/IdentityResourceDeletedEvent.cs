using Skoruba.AuditLogging.Events;
using Identity.BusinessLogic.Dtos.Configuration;

namespace Identity.BusinessLogic.Events.IdentityResource
{
    public class IdentityResourceDeletedEvent : AuditEvent
    {
        public IdentityResourceDto IdentityResource { get; set; }

        public IdentityResourceDeletedEvent(IdentityResourceDto identityResource)
        {
            IdentityResource = identityResource;
        }
    }
}