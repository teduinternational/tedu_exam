using Skoruba.AuditLogging.Events;
using Identity.BusinessLogic.Dtos.Configuration;

namespace Identity.BusinessLogic.Events.ApiResource
{
    public class ApiScopeRequestedEvent : AuditEvent
    {
        public ApiScopesDto ApiScopes { get; set; }

        public ApiScopeRequestedEvent(ApiScopesDto apiScopes)
        {
            ApiScopes = apiScopes;
        }
    }
}