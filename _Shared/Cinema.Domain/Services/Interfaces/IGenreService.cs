using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IGenreService : IBaseService<Genre>
    {
        Task<Genre> GetGenreByNameAsync(string name);
        Task<IEnumerable<Movie>> GetGenresByMovieAsync(Guid genreId);
    }
}
