using Cinema.Infrastructure.Entities;
using Cinema.Domain.Services.BaseService;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IDirectorService : IBaseService<Director>
    {
        Task<IEnumerable<Director>> GetDirectorsByMovieAsync(Guid movieId);
        Task<IEnumerable<Director>> SearchDirectorsAsync(string query);
    }
}
