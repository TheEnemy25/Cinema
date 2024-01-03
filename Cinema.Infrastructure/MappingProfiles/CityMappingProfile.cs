using AutoMapper;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Infrastructure.MappingProfiles
{
    public sealed class CityMappingProfile : Profile
    {
        public CityMappingProfile()
        {
            CreateMap<City, CityDto>();
            CreateMap<CityDto, City>()
                .ForMember(c => c.CinemaTheaters, cfg => cfg.Ignore());
        }
    }
}
