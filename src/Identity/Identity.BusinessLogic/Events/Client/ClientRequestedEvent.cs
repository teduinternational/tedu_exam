using Skoruba.AuditLogging.Events;
using Identity.BusinessLogic.Dtos.Configuration;

namespace Identity.BusinessLogic.Events.Client
{
    public class ClientRequestedEvent : AuditEvent
    {
        public ClientDto ClientDto { get; set; }

        public ClientRequestedEvent(ClientDto clientDto)
        {
            ClientDto = clientDto;
        }
    }
}