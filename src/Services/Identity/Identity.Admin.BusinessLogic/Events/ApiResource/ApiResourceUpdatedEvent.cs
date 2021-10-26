using Skoruba.AuditLogging.Events;
using Identity.Admin.BusinessLogic.Dtos.Configuration;

namespace Identity.Admin.BusinessLogic.Events.ApiResource
{
    public class ApiResourceUpdatedEvent : AuditEvent
    {
        public ApiResourceDto OriginalApiResource { get; set; }
        public ApiResourceDto ApiResource { get; set; }

        public ApiResourceUpdatedEvent(ApiResourceDto originalApiResource, ApiResourceDto apiResource)
        {
            OriginalApiResource = originalApiResource;
            ApiResource = apiResource;
        }
    }
}