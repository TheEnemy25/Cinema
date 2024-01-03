using AutoMapper;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Infrastructure.MappingProfiles
{
    public sealed class GenreMappingProfile : Profile
    {
        public GenreMappingProfile()
        {
            CreateMap<Genre, GenreDto>();
            CreateMap<GenreDto, Genre>()
                .ForMember(g => g.MovieGenres, cfg => cfg.Ignore());
        }
    }
}
