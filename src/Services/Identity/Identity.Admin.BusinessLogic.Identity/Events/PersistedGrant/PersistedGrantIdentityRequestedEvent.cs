using Skoruba.AuditLogging.Events;
using Identity.Admin.BusinessLogic.Identity.Dtos.Grant;

namespace Identity.Admin.BusinessLogic.Identity.Events.PersistedGrant
{
    public class PersistedGrantIdentityRequestedEvent : AuditEvent
    {
        public PersistedGrantDto PersistedGrant { get; set; }

        public PersistedGrantIdentityRequestedEvent(PersistedGrantDto persistedGrant)
        {
            PersistedGrant = persistedGrant;
        }
    }
}