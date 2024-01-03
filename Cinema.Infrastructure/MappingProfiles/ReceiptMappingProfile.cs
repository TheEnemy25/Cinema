using AutoMapper;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Infrastructure.MappingProfiles
{
    public sealed class ReceiptMappingProfile : Profile
    {
        public ReceiptMappingProfile()
        {
            CreateMap<Receipt, ReceiptDto>();
            CreateMap<ReceiptDto, Receipt>()
                .ForMember(r => r.Tickets, cfg => cfg.Ignore());
        }
    }
}
