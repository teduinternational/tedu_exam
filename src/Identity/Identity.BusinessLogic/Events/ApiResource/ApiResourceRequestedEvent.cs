using Skoruba.AuditLogging.Events;
using Identity.BusinessLogic.Dtos.Configuration;

namespace Identity.BusinessLogic.Events.ApiResource
{
    public class ApiResourceRequestedEvent : AuditEvent
    {
        public int ApiResourceId { get; set; }
        public ApiResourceDto ApiResource { get; set; }

        public ApiResourceRequestedEvent(int apiResourceId, ApiResourceDto apiResource)
        {
            ApiResourceId = apiResourceId;
            ApiResource = apiResource;
        }
    }
}