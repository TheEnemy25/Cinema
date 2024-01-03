using AutoMapper;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Infrastructure.MappingProfiles
{
    public sealed class CinemaTheaterMappingProfile : Profile
    {
        public CinemaTheaterMappingProfile()
        {
            CreateMap<CinemaTheater, CinemaTheaterDto>();
            CreateMap<CinemaTheaterDto, CinemaTheater>()
                .ForMember(ct => ct.Rentals, cfg => cfg.Ignore())
                .ForMember(ct => ct.Halls, cfg => cfg.Ignore())
                .ForMember(ct => ct.Employees, cfg => cfg.Ignore());
        }
    }
}
