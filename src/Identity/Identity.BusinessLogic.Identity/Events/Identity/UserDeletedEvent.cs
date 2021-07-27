using Skoruba.AuditLogging.Events;

namespace Identity.BusinessLogic.Identity.Events.Identity
{
    public class UserDeletedEvent<TUserDto> : AuditEvent
    {
        public TUserDto User { get; set; }

        public UserDeletedEvent(TUserDto user)
        {
            User = user;
        }
    }
}