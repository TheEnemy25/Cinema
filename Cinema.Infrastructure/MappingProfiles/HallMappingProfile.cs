using AutoMapper;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Infrastructure.MappingProfiles
{
    public sealed class HallMappingProfile : Profile
    {
        public HallMappingProfile()
        {
            CreateMap<Hall, HallDto>();
            CreateMap<HallDto, Hall>()
                .ForMember(h => h.Seats, cfg => cfg.Ignore())
                .ForMember(h => h.Sessions, cfg => cfg.Ignore());
        }
    }
}
