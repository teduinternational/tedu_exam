using Skoruba.AuditLogging.Events;
using Identity.Admin.BusinessLogic.Dtos.Configuration;

namespace Identity.Admin.BusinessLogic.Events.ApiResource
{
    public class ApiScopeUpdatedEvent : AuditEvent
    {
        public ApiScopesDto OriginalApiScope { get; set; }
        public ApiScopesDto ApiScope { get; set; }

        public ApiScopeUpdatedEvent(ApiScopesDto originalApiScope, ApiScopesDto apiScope)
        {
            OriginalApiScope = originalApiScope;
            ApiScope = apiScope;
        }
    }
}