using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IScreenwriterService : IBaseService<Screenwriter>
    {
        Task<IEnumerable<Screenwriter>> GetScreenwritersByMovieAsync(int movieId);
        Task<IEnumerable<Screenwriter>> SearchScreenwritersAsync(string query);
    }
}
