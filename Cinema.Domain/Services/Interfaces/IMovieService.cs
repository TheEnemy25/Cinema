using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IMovieService : IBaseService<Movie>
    {
        Task<IEnumerable<Movie>> GetTopRatedMoviesAsync(int count);
        Task<IEnumerable<Movie>> GetMoviesByGenreAsync(int genreId);
        Task<IEnumerable<Movie>> SearchMoviesAsync(string query);
        Task<IEnumerable<Movie>> GetMoviesReleasedThisYearAsync();
        Task<IEnumerable<Movie>> GetMoviesWithHighestGrossAsync(int count);
        Task<IEnumerable<Movie>> GetMoviesByDirectorAsync(int directorId);
        Task<IEnumerable<Movie>> GetMoviesByActorAsync(int actorId);
        Task<IEnumerable<Movie>> GetMoviesByCountryAsync(int countryId);
    }
}