using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;

namespace Cinema.Domain.Services.Implementation
{
    internal class SessionPromoCodeService : BaseService<SessionPromoCode>, ISessionPromoCodeService
    {
        public SessionPromoCodeService(IBaseRepository<SessionPromoCode> repository) : base(repository)
        {
        }

        public Task<decimal> CalculateSessionDiscountAsync(string promoCode, decimal originalPrice)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SessionPromoCode>> GetActiveSessionPromoCodesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SessionPromoCode>> GetAllValidSessionPromoCodesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsSessionPromoCodeValidAsync(string promoCode)
        {
            throw new NotImplementedException();
        }
    }
}
