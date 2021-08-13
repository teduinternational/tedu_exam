using Skoruba.AuditLogging.Events;
using Identity.Admin.BusinessLogic.Dtos.Configuration;

namespace Identity.Admin.BusinessLogic.Events.IdentityResource
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