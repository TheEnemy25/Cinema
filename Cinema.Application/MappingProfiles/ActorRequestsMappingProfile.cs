using AutoMapper;
using Cinema.Application.Commands.Actor;
using Cinema.Infrastructure.Dtos;

namespace Cinema.Application.MappingProfiles
{
    internal class ActorRequestsMappingProfile : Profile
    {
        public ActorRequestsMappingProfile()
        {
            CreateMap<CreateActorCommand, ActorDto>();
            CreateMap<UpdateActorCommand, ActorDto>();
        }
    }
}
