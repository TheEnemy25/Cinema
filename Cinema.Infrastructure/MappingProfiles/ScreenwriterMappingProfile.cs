using AutoMapper;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Infrastructure.MappingProfiles
{
    public sealed class ScreenwriterMappingProfile : Profile
    {
        public ScreenwriterMappingProfile()
        {
            CreateMap<Screenwriter, ScreenwriterDto>();
            CreateMap<ScreenwriterDto, Screenwriter>()
                .ForMember(s => s.MovieScreenwriters, cfg => cfg.Ignore());
        }
    }
}
