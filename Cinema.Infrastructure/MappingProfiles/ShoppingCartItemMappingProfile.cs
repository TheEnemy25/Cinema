using AutoMapper;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Infrastructure.MappingProfiles
{
    public sealed class ShoppingCartItemMappingProfile : Profile
    {
        public ShoppingCartItemMappingProfile()
        {
            CreateMap<ShoppingCartItem, ShoppingCartItemDto>();
            CreateMap<ShoppingCartItemDto, ShoppingCartItem>();
        }
    }
}
