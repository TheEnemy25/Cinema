using AutoMapper;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Infrastructure.MappingProfiles
{
    public sealed class SessionSeatMappingProfile : Profile
    {
        public SessionSeatMappingProfile()
        {
            CreateMap<SessionSeat, SessionSeatDto>();
            CreateMap<SessionSeatDto, SessionSeat>()
                .ForMember(ss => ss.Session, cfg => cfg.Ignore())
                .ForMember(ss => ss.Seat, cfg => cfg.Ignore());
        }
    }
}
