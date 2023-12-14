using Cinema.Infrastructure.Entities;
using Cinema.Domain.Services.BaseService;

namespace Cinema.Domain.Services.Interfaces
{
    public interface ISessionPromoCodeService : IBaseService<SessionPromoCode>
    {
        Task<IEnumerable<SessionPromoCode>> GetActiveSessionPromoCodesAsync();
        Task<bool> IsSessionPromoCodeValidAsync(string promoCode);
        Task<decimal> CalculateSessionDiscountAsync(string promoCode, decimal originalPrice);
        Task<IEnumerable<SessionPromoCode>> GetAllValidSessionPromoCodesAsync();
    }
}