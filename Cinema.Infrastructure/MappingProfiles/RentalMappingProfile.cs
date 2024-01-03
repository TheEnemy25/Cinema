using AutoMapper;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Infrastructure.MappingProfiles
{
    public sealed class RentalMappingProfile : Profile
    {
        public RentalMappingProfile()
        {
            CreateMap<Rental, RentalDto>();
            CreateMap<RentalDto, Rental>()
                .ForMember(r => r.Movie, cfg => cfg.Ignore())
                .ForMember(r => r.CinemaTheater, cfg => cfg.Ignore());
        }
    }
}
