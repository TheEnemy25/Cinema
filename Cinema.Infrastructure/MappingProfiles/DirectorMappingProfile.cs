using AutoMapper;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Infrastructure.MappingProfiles
{
    public sealed class DirectorMappingProfile : Profile
    {
        public DirectorMappingProfile()
        {
            CreateMap<Director, DirectorDto>();
            CreateMap<DirectorDto, Director>()
                .ForMember(d => d.MovieDirectors, cfg => cfg.Ignore());
        }
    }
}
