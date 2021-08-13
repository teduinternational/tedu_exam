using Skoruba.AuditLogging.Events;
using Identity.Admin.BusinessLogic.Dtos.Configuration;

namespace Identity.Admin.BusinessLogic.Events.ApiScope
{
    public class ApiScopePropertiesRequestedEvent : AuditEvent
    {
        public ApiScopePropertiesRequestedEvent(int apiScopeId, ApiScopePropertiesDto apiScopeProperties)
        {
            ApiScopeId = apiScopeId;
            ApiResourceProperties = apiScopeProperties;
        }

        public int ApiScopeId { get; set; }
        public ApiScopePropertiesDto ApiResourceProperties { get; }
    }
}