using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IProducerService : IBaseService<Producer>
    {
        Task<IEnumerable<Producer>> GetProducersByMovieAsync(int movieId);
        Task<IEnumerable<Producer>> SearchProducersAsync(string query);
    }
}
