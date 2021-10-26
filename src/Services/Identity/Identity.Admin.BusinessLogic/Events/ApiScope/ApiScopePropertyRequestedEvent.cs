using Skoruba.AuditLogging.Events;
using Identity.Admin.BusinessLogic.Dtos.Configuration;

namespace Identity.Admin.BusinessLogic.Events.ApiScope
{
    public class ApiScopePropertyRequestedEvent : AuditEvent
    {
        public ApiScopePropertyRequestedEvent(int apiScopePropertyId, ApiScopePropertiesDto apiScopeProperty)
        {
            ApiScopePropertyId = apiScopePropertyId;
            ApiScopeProperty = apiScopeProperty;
        }

        public int ApiScopePropertyId { get; set; }

        public ApiScopePropertiesDto ApiScopeProperty { get; set; }
    }
}