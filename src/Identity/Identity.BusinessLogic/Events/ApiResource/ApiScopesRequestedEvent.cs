using Skoruba.AuditLogging.Events;
using Identity.BusinessLogic.Dtos.Configuration;

namespace Identity.BusinessLogic.Events.ApiResource
{
    public class ApiScopesRequestedEvent : AuditEvent
    {
        public ApiScopesDto ApiScope { get; set; }

        public ApiScopesRequestedEvent(ApiScopesDto apiScope)
        {
            ApiScope = apiScope;
        }
    }
}