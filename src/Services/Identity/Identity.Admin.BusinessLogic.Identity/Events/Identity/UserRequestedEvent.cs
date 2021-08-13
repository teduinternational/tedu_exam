using Skoruba.AuditLogging.Events;
using Identity.Admin.BusinessLogic.Identity.Dtos.Identity;

namespace Identity.Admin.BusinessLogic.Identity.Events.Identity
{
    public class UserRequestedEvent<TUserDto> : AuditEvent
    {
        public TUserDto UserDto { get; set; }

        public UserRequestedEvent(TUserDto userDto)
        {
            UserDto = userDto;
        }
    }
}