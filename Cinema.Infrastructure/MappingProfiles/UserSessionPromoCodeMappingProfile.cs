using AutoMapper;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Infrastructure.MappingProfiles
{
    public class UserSessionPromoCodeMappingProfile : Profile
    {
        public UserSessionPromoCodeMappingProfile()
        {
            CreateMap<UserSessionPromoCode, UserSessionPromoCodeDto>();
            CreateMap<UserSessionPromoCodeDto, UserSessionPromoCode>()
                .ForMember(uspc => uspc.User, cfg => cfg.Ignore())
                .ForMember(uspc => uspc.SessionPromoCode, cfg => cfg.Ignore());
        }
    }
}
