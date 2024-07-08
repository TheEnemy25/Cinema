using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinema.Application.Queries.Movie
{
    public record GetMovieByIdQuery(Guid Id) : IRequest<MovieDto>;

    internal class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, MovieDto>
    {
        private readonly IMovieService _movieService;
        private readonly ILogger<GetMovieByIdQueryHandler> _logger;

        public GetMovieByIdQueryHandler(IMovieService movieService, ILogger<GetMovieByIdQueryHandler> logger)
        {
            _movieService = movieService;
            _logger = logger;
        }

        public async Task<MovieDto> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            return await _movieService.GetByIdAsync(request.Id, cancellationToken);
        }
    }
}
