using Skoruba.AuditLogging.Events;
using Identity.Admin.BusinessLogic.Dtos.Configuration;

namespace Identity.Admin.BusinessLogic.Events.IdentityResource
{
    public class IdentityResourceAddedEvent : AuditEvent
    {
        public IdentityResourceDto IdentityResource { get; set; }

        public IdentityResourceAddedEvent(IdentityResourceDto identityResource)
        {
            IdentityResource = identityResource;
        }
    }
}