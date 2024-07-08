using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinema.Application.Queries.Movie
{
    public record GetAllMoviesQuery : IRequest<IEnumerable<MovieDto>>;

    internal class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, IEnumerable<MovieDto>>
    {
        private readonly IMovieService _movieService;
        private readonly ILogger<GetAllMoviesQueryHandler> _logger;

        public GetAllMoviesQueryHandler(IMovieService movieService, ILogger<GetAllMoviesQueryHandler> logger)
        {
            _movieService = movieService;
            _logger = logger;
        }

        public async Task<IEnumerable<MovieDto>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            var movie = await _movieService.GetAllAsync(cancellationToken);

            return movie;
        }
    }
}
