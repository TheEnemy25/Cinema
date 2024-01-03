using AutoMapper;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Infrastructure.MappingProfiles
{
    public sealed class MovieMappingProfile : Profile
    {
        public MovieMappingProfile()
        {
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>()
                .ForMember(m => m.MovieDirectors, cfg => cfg.Ignore())
                .ForMember(m => m.MovieActors, cfg => cfg.Ignore())
                .ForMember(m => m.MovieGenres, cfg => cfg.Ignore())
                .ForMember(m => m.MovieProducers, cfg => cfg.Ignore())
                .ForMember(m => m.MovieScreenwriters, cfg => cfg.Ignore())
                .ForMember(m => m.MovieStudios, cfg => cfg.Ignore())
                .ForMember(m => m.Reviews, cfg => cfg.Ignore())
                .ForMember(m => m.Sessions, cfg => cfg.Ignore())
                .ForMember(m => m.Rentals, cfg => cfg.Ignore())
                .ForMember(m => m.MovieProductionCountries, cfg => cfg.Ignore());
        }
    }
}
