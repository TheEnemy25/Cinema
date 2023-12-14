using Cinema.Infrastructure.Entities;
using Cinema.Domain.Services.BaseService;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IScreenwriterService : IBaseService<Screenwriter>
    {
        Task<IEnumerable<Screenwriter>> GetScreenwritersByMovieAsync(Guid movieId);
        Task<IEnumerable<Screenwriter>> SearchScreenwritersAsync(string query);
    }
}
