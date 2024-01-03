using AutoMapper;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Infrastructure.MappingProfiles
{
    public sealed class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>()
                .ForMember(p => p.ProductPromoCodes, cfg => cfg.Ignore())
                .ForMember(p => p.ShoppingCartItems, cfg => cfg.Ignore());
        }
    }
}
