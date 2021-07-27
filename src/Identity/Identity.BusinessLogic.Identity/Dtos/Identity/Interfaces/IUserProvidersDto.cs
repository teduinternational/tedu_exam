using System.Collections.Generic;

namespace Identity.BusinessLogic.Identity.Dtos.Identity.Interfaces
{
    public interface IUserProvidersDto : IUserProviderDto
    {
        List<IUserProviderDto> Providers { get; }
    }
}
