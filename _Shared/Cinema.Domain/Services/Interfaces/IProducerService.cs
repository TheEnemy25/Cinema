using Cinema.Domain.Services.BaseService;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IProducerService : IBaseService<Producer, ProducerDto>
    {
        Task<IEnumerable<ProducerDto>> GetProducersByMovieAsync(Guid movieId, CancellationToken cancellationToken = default);
        Task<IEnumerable<ProducerDto>> SearchProducersAsync(string query, CancellationToken cancellationToken = default);
    }
}
