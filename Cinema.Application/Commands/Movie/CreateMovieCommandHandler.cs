using AutoMapper;
using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinema.Application.Commands.Movie
{
    public record CreateMovieCommand(string Title, int AgeRestriction, string Description, string ImageLink, string TrailerLink, double Rating, TimeSpan Duration, DateTime ReleaseDate) : IRequest<Guid>;

    internal sealed class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, Guid>
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateMovieCommandHandler> _logger;

        public CreateMovieCommandHandler(IMovieService movieService, IMapper mapper, ILogger<CreateMovieCommandHandler> logger)
        {
            _movieService = movieService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = _mapper.Map<MovieDto>(request);

            _logger.LogInformation($"Creation of movie begins");

            var movieId = await _movieService.CreateAsync(movie, cancellationToken);

            _logger.LogInformation($"Creation of movie with id {movieId} was successfull");

            return movieId;
        }
    }
}