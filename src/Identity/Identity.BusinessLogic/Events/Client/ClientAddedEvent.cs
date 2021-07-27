using Skoruba.AuditLogging.Events;
using Identity.BusinessLogic.Dtos.Configuration;

namespace Identity.BusinessLogic.Events.Client
{
    public class ClientAddedEvent : AuditEvent
    {
        public ClientDto Client { get; set; }

        public ClientAddedEvent(ClientDto client)
        {
            Client = client;
        }
    }
}