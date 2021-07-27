using Skoruba.AuditLogging.Events;
using Identity.BusinessLogic.Dtos.Configuration;

namespace Identity.BusinessLogic.Events.Client
{
    public class ClientUpdatedEvent : AuditEvent
    {
        public ClientDto OriginalClient { get; set; }
        public ClientDto Client { get; set; }

        public ClientUpdatedEvent(ClientDto originalClient, ClientDto client)
        {
            OriginalClient = originalClient;
            Client = client;
        }
    }
}