using AutoMapper;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Infrastructure.MappingProfiles
{
    public sealed class ProducerMappingProfile : Profile
    {
        public ProducerMappingProfile()
        {
            CreateMap<Producer, ProducerDto>();
            CreateMap<ProducerDto, Producer>()
                .ForMember(p => p.MovieProducers, cfg => cfg.Ignore());
        }
    }
}
