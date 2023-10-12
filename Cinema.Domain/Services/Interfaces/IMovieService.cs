using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IMovieService : IBaseService<Movie>
    {
        Task<IEnumerable<Movie>> GetTopRatedMoviesAsync(int count);
        Task<IEnumerable<Movie>> GetMoviesByGenreAsync(Guid genreId);
        Task<IEnumerable<Movie>> SearchMoviesAsync(string query);
        Task<IEnumerable<Movie>> GetMoviesReleasedThisYearAsync();
        Task<IEnumerable<Movie>> GetMoviesByDirectorAsync(Guid directorId);
        Task<IEnumerable<Movie>> GetMoviesByActorAsync(Guid actorId);
        Task<IEnumerable<Movie>> GetMoviesByCountryAsync(Guid countryId);
    }
}