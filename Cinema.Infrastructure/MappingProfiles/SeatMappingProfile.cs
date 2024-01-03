using AutoMapper;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Infrastructure.MappingProfiles
{
    public sealed class SeatMappingProfile : Profile
    {
        public SeatMappingProfile()
        {
            CreateMap<Seat, SeatDto>();
            CreateMap<SeatDto, Seat>()
                .ForMember(s => s.SessionSeats, cfg => cfg.Ignore())
                .ForMember(s => s.ShoppingCartItems, cfg => cfg.Ignore());
        }
    }
}
