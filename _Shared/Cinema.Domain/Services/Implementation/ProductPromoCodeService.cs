using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal class ProductPromoCodeService : BaseService<ProductPromoCode>, IProductPromoCodeService
    {
        public ProductPromoCodeService(IBaseRepository<ProductPromoCode> repository) : base(repository)
        {
        }

        public async Task<decimal> CalculateProductDiscountAsync(string promoCode, decimal originalPrice)
        {
            var productPromoCode = await _repository
                .Query()
                .Where(code => code.PromoCode == promoCode)
                .FirstOrDefaultAsync();

            if (productPromoCode != null)
            {

                if (productPromoCode.MaxUsageCount > 0)
                {
                    decimal discountAmount = originalPrice * (productPromoCode.DiscountPercentage / 100);

                    productPromoCode.MaxUsageCount--;

                    await _repository.UpdateAsync(productPromoCode);

                    return discountAmount;
                }
            }
            return 0;
        }

        public async Task<IEnumerable<ProductPromoCode>> GetActiveProductPromoCodesAsync()
        {
            var activePromoCodes = await _repository
                .Query()
                .Where(code => code.MaxUsageCount > 0)
                .ToListAsync();

            return activePromoCodes;
        }

        public async Task<IEnumerable<ProductPromoCode>> GetAllValidProductPromoCodesAsync()
        {
            var validPromoCodes = await _repository
                    .Query()
                    .ToListAsync();

            return validPromoCodes;
        }

        public async Task<bool> IsProductPromoCodeValidAsync(string promoCode)
        {
            var isValid = await _repository
                .Query()
                .AnyAsync(code => code.PromoCode == promoCode && code.MaxUsageCount > 0);

            return isValid;
        }
    }
}