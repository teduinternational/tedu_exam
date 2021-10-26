using Skoruba.AuditLogging.Events;
namespace Identity.Admin.BusinessLogic.Identity.Events.Identity
{
    public class RolesRequestedEvent<TRolesDto> : AuditEvent
    {
        public TRolesDto Roles { get; set; }

        public RolesRequestedEvent(TRolesDto roles)
        {
            Roles = roles;
        }
    }
}