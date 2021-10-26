using Skoruba.AuditLogging.Events;
using Identity.Admin.BusinessLogic.Dtos.Configuration;

namespace Identity.Admin.BusinessLogic.Events.Client
{
    public class ClientUpdatedEvent: AuditEvent
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