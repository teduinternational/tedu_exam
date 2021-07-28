using Skoruba.AuditLogging.Events;
using Identity.Admin.BusinessLogic.Dtos.Configuration;

namespace Identity.Admin.BusinessLogic.Events.ApiResource
{
    public class ApiResourceDeletedEvent : AuditEvent
    {
        public ApiResourceDto ApiResource { get; set; }

        public ApiResourceDeletedEvent(ApiResourceDto apiResource)
        {
            ApiResource = apiResource;
        }
    }
}