using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;

namespace Cinema.Domain.Services.Implementation
{
    internal class ProductPromoCodeService : BaseService<ProductPromoCode>, IProductPromoCodeService
    {
        public ProductPromoCodeService(IBaseRepository<ProductPromoCode> repository) : base(repository)
        {
        }

        public Task<decimal> CalculateProductDiscountAsync(string promoCode, decimal originalPrice)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductPromoCode>> GetActiveProductPromoCodesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductPromoCode>> GetAllValidProductPromoCodesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsProductPromoCodeValidAsync(string promoCode)
        {
            throw new NotImplementedException();
        }
    }
}
