using AutoMapper;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Infrastructure.MappingProfiles
{
    public sealed class StudioMappingProfile : Profile
    {
        public StudioMappingProfile()
        {
            CreateMap<Studio, StudioDto>();
            CreateMap<StudioDto, Studio>();
        }
    }
}
