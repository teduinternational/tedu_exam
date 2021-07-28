using Skoruba.AuditLogging.Events;
using Identity.Admin.BusinessLogic.Dtos.Configuration;

namespace Identity.Admin.BusinessLogic.Events.ApiResource
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