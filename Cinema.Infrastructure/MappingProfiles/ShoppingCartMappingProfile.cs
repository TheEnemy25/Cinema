using AutoMapper;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Infrastructure.MappingProfiles
{
    public sealed class ShoppingCartMappingProfile : Profile
    {
        public ShoppingCartMappingProfile()
        {
            CreateMap<ShoppingCart, ShoppingCartDto>();
            CreateMap<ShoppingCartDto, ShoppingCart>()
                .ForMember(sc => sc.Receipt, cfg => cfg.Ignore())
                .ForMember(sc => sc.User, cfg => cfg.Ignore());
        }
    }
}
