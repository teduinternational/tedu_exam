using Identity.Admin.BusinessLogic.Identity.Helpers;

namespace Identity.Admin.BusinessLogic.Identity.Resources
{
    public class PersistedGrantAspNetIdentityServiceResources : IPersistedGrantAspNetIdentityServiceResources
    {
        public virtual ResourceMessage PersistedGrantDoesNotExist()
        {
            return new ResourceMessage()
            {
                Code = nameof(PersistedGrantDoesNotExist),
                Description = PersistedGrantServiceResource.PersistedGrantDoesNotExist
            };
        }

        public virtual ResourceMessage PersistedGrantWithSubjectIdDoesNotExist()
        {
            return new ResourceMessage()
            {
                Code = nameof(PersistedGrantWithSubjectIdDoesNotExist),
                Description = PersistedGrantServiceResource.PersistedGrantWithSubjectIdDoesNotExist
            };
        }
    }
}
