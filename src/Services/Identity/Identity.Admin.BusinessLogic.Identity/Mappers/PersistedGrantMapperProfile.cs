using AutoMapper;
using IdentityServer4.EntityFramework.Entities;
using Identity.Admin.BusinessLogic.Identity.Dtos.Grant;
using Identity.Admin.EntityFramework.Entities;
using Identity.Admin.EntityFramework.Extensions.Common;

namespace Identity.Admin.BusinessLogic.Identity.Mappers
{
    public class PersistedGrantMapperProfile : Profile
    {
        public PersistedGrantMapperProfile()
        {
            // entity to model
            CreateMap<PersistedGrant, PersistedGrantDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PersistedGrantDataView, PersistedGrantDto>(MemberList.Destination);

            CreateMap<PagedList<PersistedGrantDataView>, PersistedGrantsDto>(MemberList.Destination)
                .ForMember(x => x.PersistedGrants,
                    opt => opt.MapFrom(src => src.Data));

            CreateMap<PagedList<PersistedGrant>, PersistedGrantsDto>(MemberList.Destination)
                .ForMember(x => x.PersistedGrants,
                    opt => opt.MapFrom(src => src.Data));            
        }
    }
}
