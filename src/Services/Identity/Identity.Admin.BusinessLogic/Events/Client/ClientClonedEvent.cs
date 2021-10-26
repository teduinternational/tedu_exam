using Skoruba.AuditLogging.Events;
using Identity.Admin.BusinessLogic.Dtos.Configuration;

namespace Identity.Admin.BusinessLogic.Events.Client
{
    public class ClientClonedEvent : AuditEvent
    {
        public ClientCloneDto Client { get; set; }

        public ClientClonedEvent(ClientCloneDto client)
        {
            Client = client;
        }
    }
}