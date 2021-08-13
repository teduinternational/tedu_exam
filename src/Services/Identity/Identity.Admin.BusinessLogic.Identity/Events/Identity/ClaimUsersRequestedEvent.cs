using Skoruba.AuditLogging.Events;
using Identity.Admin.BusinessLogic.Identity.Dtos.Identity;

namespace Identity.Admin.BusinessLogic.Identity.Events.Identity
{
    public class ClaimUsersRequestedEvent<TUsersDto> : AuditEvent
    {
        public TUsersDto Users { get; set; }

        public ClaimUsersRequestedEvent(TUsersDto users)
        {
            Users = users;
        }
    }
}