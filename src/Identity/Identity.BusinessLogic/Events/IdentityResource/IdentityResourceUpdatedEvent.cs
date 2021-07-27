using Skoruba.AuditLogging.Events;
using Identity.BusinessLogic.Dtos.Configuration;

namespace Identity.BusinessLogic.Events.IdentityResource
{
    public class IdentityResourceUpdatedEvent : AuditEvent
    {
        public IdentityResourceDto OriginalIdentityResource { get; set; }
        public IdentityResourceDto IdentityResource { get; set; }

        public IdentityResourceUpdatedEvent(IdentityResourceDto originalIdentityResource, IdentityResourceDto identityResource)
        {
            OriginalIdentityResource = originalIdentityResource;
            IdentityResource = identityResource;
        }
    }
}