using Skoruba.AuditLogging.Events;
using Identity.BusinessLogic.Dtos.Configuration;

namespace Identity.BusinessLogic.Events.ApiResource
{
    public class ApiScopeAddedEvent : AuditEvent
    {
        public ApiScopesDto ApiScope { get; set; }

        public ApiScopeAddedEvent(ApiScopesDto apiScope)
        {
            ApiScope = apiScope;
        }
    }
}