using Cinema.Domain.Services.BaseService;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IDiscountService : IBaseService<Discount, DiscountDto>
    {
        Task<IEnumerable<DiscountDto>> GetDiscountsByMovieAsync(Guid movieId, CancellationToken cancellationToken = default);
        Task<IEnumerable<DiscountDto>> GetDiscountsBySessionAsync(Guid sessionId, CancellationToken cancellationToken = default);
        Task<IEnumerable<DiscountDto>> GetActiveDiscountsAsync(CancellationToken cancellationToken = default);
    }
}
