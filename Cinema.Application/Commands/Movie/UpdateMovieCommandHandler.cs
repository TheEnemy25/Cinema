using AutoMapper;
using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinema.Application.Commands.Movie
{
    public record UpdateMovieCommand(Guid Id, string Title, int AgeRestriction, string Description, string ImageLink, string TrailerLink, double Rating, TimeSpan Duration, DateTime ReleaseDate) : IRequest<MovieDto>;

    internal sealed class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, MovieDto>
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateMovieCommandHandler> _logger;

        public UpdateMovieCommandHandler(IMovieService movieService, IMapper mapper, ILogger<UpdateMovieCommandHandler> logger)
        {
            _movieService = movieService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<MovieDto> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = _mapper.Map<MovieDto>(request);

            _logger.LogInformation($"Update of movie with id {request.Id} begins");

            await _movieService.UpdateAsync(movie, cancellationToken);

            _logger.LogInformation($"Movie with id {request.Id} was successfully updated");

            return movie;
        }
    }
}
