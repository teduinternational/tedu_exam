using Skoruba.AuditLogging.Events;

namespace Identity.Admin.BusinessLogic.Identity.Events.Identity
{
    public class UsersRequestedEvent<TUsersDto> : AuditEvent
    {
        public TUsersDto Users { get; set; }

        public UsersRequestedEvent(TUsersDto users)
        {
            Users = users;
        }
    }
}