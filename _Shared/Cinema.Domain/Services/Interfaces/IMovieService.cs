using Cinema.Domain.Services.BaseService;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IMovieService : IBaseService<Movie, MovieDto>
    {
        Task<IEnumerable<MovieDto>> GetTopRatedMoviesAsync(int count, CancellationToken cancellationToken = default);
        Task<IEnumerable<MovieDto>> GetMoviesByGenreAsync(Guid genreId, CancellationToken cancellationToken = default);
        Task<IEnumerable<MovieDto>> SearchMoviesAsync(string query, CancellationToken cancellationToken = default);
        Task<IEnumerable<MovieDto>> GetMoviesReleasedThisYearAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<MovieDto>> GetMoviesByDirectorAsync(Guid directorId, CancellationToken cancellationToken = default);
        Task<IEnumerable<MovieDto>> GetMoviesByActorAsync(Guid actorId, CancellationToken cancellationToken = default);
        Task<IEnumerable<MovieDto>> GetMoviesByCountryAsync(Guid countryId, CancellationToken cancellationToken = default);
    }
}