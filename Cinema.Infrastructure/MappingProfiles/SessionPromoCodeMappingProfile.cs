using AutoMapper;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Infrastructure.MappingProfiles
{
    public sealed class SessionPromoCodeMappingProfile : Profile
    {
        public SessionPromoCodeMappingProfile()
        {
            CreateMap<SessionPromoCode, SessionPromoCodeDto>();
            CreateMap<SessionPromoCodeDto, SessionPromoCode>()
                .ForMember(spc => spc.UserSessionPromoCodes, cfg => cfg.Ignore());
        }
    }
}
