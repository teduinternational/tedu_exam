using Identity.BusinessLogic.Identity.Dtos.Identity.Interfaces;
using System.Collections.Generic;

namespace Identity.BusinessLogic.Identity.Dtos.Identity.Base
{
    public class BaseUserDto<TUserId> : IBaseUserDto
    {
        public TUserId Id { get; set; }

        public bool IsDefaultId() => EqualityComparer<TUserId>.Default.Equals(Id, default(TUserId));

        object IBaseUserDto.Id => Id;
    }
}