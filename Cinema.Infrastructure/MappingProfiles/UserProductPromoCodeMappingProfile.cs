using AutoMapper;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Infrastructure.MappingProfiles
{
    public class UserProductPromoCodeMappingProfile : Profile
    {
        public UserProductPromoCodeMappingProfile()
        {
            CreateMap<UserProductPromoCode, UserProductPromoCodeDto>();
            CreateMap<UserProductPromoCodeDto, UserProductPromoCode>()
                .ForMember(uppc => uppc.User, cfg => cfg.Ignore())
                .ForMember(uppc => uppc.ProductPromoCode, cfg => cfg.Ignore());
        }
    }
}
