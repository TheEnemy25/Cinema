using AutoMapper;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Infrastructure.MappingProfiles
{
    public sealed class ActorMappingProfile : Profile
    {
        public ActorMappingProfile()
        {
            CreateMap<Actor, ActorDto>();
            CreateMap<ActorDto, Actor>()
                .ForMember(a => a.MovieActors, cfg => cfg.Ignore());
        }
    }
}
