using AutoMapper;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Infrastructure.MappingProfiles
{
    public sealed class DiscountMappingProfile : Profile
    {
        public DiscountMappingProfile()
        {
            CreateMap<Discount, DiscountDto>();
            CreateMap<DiscountDto, Discount>()
                .ForMember(d => d.Sessions, cfg => cfg.Ignore())
                .ForMember(d => d.Products, cfg => cfg.Ignore());
        }
    }
}
