using Skoruba.AuditLogging.Events;
using Identity.BusinessLogic.Dtos.Configuration;

namespace Identity.BusinessLogic.Events.Client
{
    public class ClientDeletedEvent : AuditEvent
    {
        public ClientDto Client { get; set; }

        public ClientDeletedEvent(ClientDto client)
        {
            Client = client;
        }
    }
}