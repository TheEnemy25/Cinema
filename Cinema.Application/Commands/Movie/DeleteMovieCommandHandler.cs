using Cinema.Domain.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinema.Application.Commands.Movie
{
    public record DeleteMovieCommand(Guid Id) : IRequest;

    internal sealed class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand>
    {
        private readonly IMovieService _movieService;
        private readonly ILogger<DeleteMovieCommandHandler> _logger;

        public DeleteMovieCommandHandler(IMovieService movieService, ILogger<DeleteMovieCommandHandler> logger)
        {
            _movieService = movieService;
            _logger = logger;
        }

        public async Task Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = request.Id;

            _logger.LogInformation($"Deletion of movie with id {movie} begins");

            await _movieService.DeleteAsync(movie, cancellationToken);

            _logger.LogInformation($"Movie with id {movie} was successfully deleted");
        }
    }
}
