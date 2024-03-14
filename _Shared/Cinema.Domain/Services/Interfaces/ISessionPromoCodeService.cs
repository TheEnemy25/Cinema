using Cinema.Domain.Services.BaseService;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Domain.Services.Interfaces
{
    public interface ISessionPromoCodeService : IBaseService<SessionPromoCode, SessionPromoCodeDto>
    {
        Task<IEnumerable<SessionPromoCodeDto>> GetActiveSessionPromoCodesAsync(CancellationToken cancellationToken = default);
        Task<bool> IsSessionPromoCodeValidAsync(string promoCode, CancellationToken cancellationToken = default);
        Task<decimal> CalculateSessionDiscountAsync(string promoCode, decimal originalPrice, CancellationToken cancellationToken = default);
        Task<IEnumerable<SessionPromoCodeDto>> GetAllValidSessionPromoCodesAsync(CancellationToken cancellationToken = default);
    }
}