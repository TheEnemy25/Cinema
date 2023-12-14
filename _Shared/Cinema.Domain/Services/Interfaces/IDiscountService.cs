using Cinema.Infrastructure.Entities;
using Cinema.Domain.Services.BaseService;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IDiscountService : IBaseService<Discount>
    {
        Task<IEnumerable<Discount>> GetDiscountsByMovieAsync(Guid movieId);
        Task<IEnumerable<Discount>> GetDiscountsBySessionAsync(Guid sessionId);
        Task<IEnumerable<Discount>> GetActiveDiscountsAsync();
    }
}
