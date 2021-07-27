using Skoruba.AuditLogging.Events;
using Identity.BusinessLogic.Identity.Dtos.Grant;

namespace Identity.BusinessLogic.Identity.Events.PersistedGrant
{
    public class PersistedGrantsIdentityByUsersRequestedEvent : AuditEvent
    {
        public PersistedGrantsDto PersistedGrants { get; set; }

        public PersistedGrantsIdentityByUsersRequestedEvent(PersistedGrantsDto persistedGrants)
        {
            PersistedGrants = persistedGrants;
        }
    }
}