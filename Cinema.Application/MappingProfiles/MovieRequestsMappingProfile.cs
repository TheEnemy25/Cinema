using AutoMapper;
using Cinema.Application.Commands.Movie;
using Cinema.Infrastructure.Dtos;

namespace Cinema.Application.MappingProfiles
{
    internal class MovieRequestsMappingProfile : Profile
    {
        public MovieRequestsMappingProfile()
        {
            CreateMap<CreateMovieCommand, MovieDto>();
            CreateMap<UpdateMovieCommand, MovieDto>();
        }
    }
}
