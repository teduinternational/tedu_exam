using System.Collections.Generic;

namespace Identity.Admin.BusinessLogic.Identity.Dtos.Identity.Interfaces
{
    public interface IUserProvidersDto : IUserProviderDto
    {
        List<IUserProviderDto> Providers { get; }
    }
}
