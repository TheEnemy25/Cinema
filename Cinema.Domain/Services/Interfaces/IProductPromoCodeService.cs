using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IProductPromoCodeService : IBaseService<ProductPromoCode>
    {
        Task<IEnumerable<ProductPromoCode>> GetActiveProductPromoCodesAsync();
        Task<bool> IsProductPromoCodeValidAsync(string promoCode);
        Task<decimal> CalculateProductDiscountAsync(string promoCode, decimal originalPrice);
        Task<IEnumerable<ProductPromoCode>> GetAllValidProductPromoCodesAsync();
    }
}
