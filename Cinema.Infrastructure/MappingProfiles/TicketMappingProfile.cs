using AutoMapper;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Infrastructure.MappingProfiles
{
    public class TicketMappingProfile : Profile
    {
        public TicketMappingProfile()
        {
            CreateMap<Ticket, TicketDto>();
            CreateMap<TicketDto, Ticket>()
                .ForMember(t => t.Session, cfg => cfg.Ignore())
                .ForMember(t => t.SessionSeat, cfg => cfg.Ignore())
                .ForMember(t => t.Receipt, cfg => cfg.Ignore())
                .ForMember(t => t.ShoppingCartItems, cfg => cfg.Ignore());
        }
    }
}
