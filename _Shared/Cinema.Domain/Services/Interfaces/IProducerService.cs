using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IProducerService : IBaseService<Producer>
    {
        Task<IEnumerable<Producer>> GetProducersByMovieAsync(Guid movieId);
        Task<IEnumerable<Producer>> SearchProducersAsync(string query);
    }
}
