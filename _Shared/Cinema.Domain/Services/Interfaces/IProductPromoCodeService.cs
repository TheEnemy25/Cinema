using Cinema.Domain.Services.BaseService;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IProductPromoCodeService : IBaseService<ProductPromoCode, ProductPromoCodeDto>
    {
        Task<IEnumerable<ProductPromoCodeDto>> GetActiveProductPromoCodesAsync(CancellationToken cancellationToken = default);
        Task<bool> IsProductPromoCodeValidAsync(string promoCode, CancellationToken cancellationToken = default);
        Task<decimal> CalculateProductDiscountAsync(string promoCode, decimal originalPrice, CancellationToken cancellationToken = default);
        Task<IEnumerable<ProductPromoCodeDto>> GetAllValidProductPromoCodesAsync(CancellationToken cancellationToken = default);
    }
}
