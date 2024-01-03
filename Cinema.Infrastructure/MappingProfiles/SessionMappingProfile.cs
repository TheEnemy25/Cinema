using AutoMapper;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Infrastructure.MappingProfiles
{
    public sealed class SessionMappingProfile : Profile 
    {
        public SessionMappingProfile()
        {
            CreateMap<Session, SessionDto>();
            CreateMap<SessionDto, Session>()
                .ForMember(s => s.SessionPromoCodes, cfg => cfg.Ignore())
                .ForMember(s => s.SessionSeats, cfg => cfg.Ignore())
                .ForMember(s => s.Tickets, cfg => cfg.Ignore());
        }
    }
}
