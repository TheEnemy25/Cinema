using AutoMapper;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal sealed class ProductPromoCodeService : BaseService<ProductPromoCode, ProductPromoCodeDto>, IProductPromoCodeService
    {
        private readonly IMapper _mapper;

        public ProductPromoCodeService(IBaseRepository<ProductPromoCode> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<decimal> CalculateProductDiscountAsync(string promoCode, decimal originalPrice, CancellationToken cancellationToken)
        {
            var productPromoCode = await _repository
                .Query()
                .Where(ppc => ppc.PromoCode == promoCode)
                .FirstOrDefaultAsync(cancellationToken);

            if (productPromoCode != null)
            {

                if (productPromoCode.MaxUsageCount > 0)
                {
                    decimal discountAmount = originalPrice * (productPromoCode.DiscountPercentage / 100);

                    productPromoCode.MaxUsageCount--;

                    await _repository.UpdateAsync(productPromoCode, cancellationToken);

                    return discountAmount;
                }
            }
            return 0;
        }

        public async Task<IEnumerable<ProductPromoCodeDto>> GetActiveProductPromoCodesAsync(CancellationToken cancellationToken)
        {
            var activePromoCodes = await _repository
                .Query()
                .Where(ppc => ppc.MaxUsageCount > 0)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ProductPromoCodeDto>>(activePromoCodes);
        }

        public async Task<IEnumerable<ProductPromoCodeDto>> GetAllValidProductPromoCodesAsync(CancellationToken cancellationToken)
        {
            var validPromoCodes = await _repository
                    .Query()
                    .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ProductPromoCodeDto>>(validPromoCodes);
        }

        public async Task<bool> IsProductPromoCodeValidAsync(string promoCode, CancellationToken cancellationToken)
        {
            var isValid = await _repository
                .Query()
                .AnyAsync(code => code.PromoCode == promoCode && code.MaxUsageCount > 0, cancellationToken);

            return isValid;
        }
    }
}