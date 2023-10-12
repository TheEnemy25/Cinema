using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal class SessionPromoCodeService : BaseService<SessionPromoCode>, ISessionPromoCodeService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionPromoCodeService(IBaseRepository<SessionPromoCode> repository, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor) : base(repository)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<decimal> CalculateSessionDiscountAsync(string promoCode, decimal originalPrice)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            if (user == null)
            {
                return 0;
            }

            bool hasUsedSessionPromoCode = await _repository
               .Query()
               .AnyAsync(code => code.PromoCode == promoCode && code.UserSessionPromoCodes.Any(sessionCode => sessionCode.UserId == user.Id));

            if (hasUsedSessionPromoCode)
            {
                return 0;
            }
             
            var sessionPromoCode = await _repository
                .Query()
                .FirstOrDefaultAsync(code => code.PromoCode == promoCode);

            if (sessionPromoCode != null)
            {
                if (sessionPromoCode.MaxUsageCount > 0)
                {
                    decimal discountAmount = originalPrice * (sessionPromoCode.DiscountPercentage / 100);

                    sessionPromoCode.MaxUsageCount--;

                    await _repository.UpdateAsync(sessionPromoCode);

                    var promoCodeUsage = new UserSessionPromoCode
                    {
                        SessionPromoCodeId = sessionPromoCode.Id,
                        UsageDate = DateTime.Now,
                        UserId = user.Id
                    };

                    await _repository.AddAsync(sessionPromoCode);

                    return discountAmount;
                }
            }

            return 0;
        }

        public async Task<IEnumerable<SessionPromoCode>> GetActiveSessionPromoCodesAsync()
        {
            var activePromoCodes = await _repository
                .Query()
                .Where(spc => spc.MaxUsageCount > 0)
                .ToListAsync();

            return activePromoCodes;
        }

        public async Task<IEnumerable<SessionPromoCode>> GetAllValidSessionPromoCodesAsync()
        {
            var validPromoCodes = await _repository
               .Query()
               .Where(spc => spc.MaxUsageCount > 0)
               .ToListAsync();

            return validPromoCodes;
        }

        public async Task<bool> IsSessionPromoCodeValidAsync(string promoCode)
        {
            var isValid = await _repository
                .Query()
                .AnyAsync(spc => spc.PromoCode == promoCode && spc.MaxUsageCount > 0);

            return isValid;
        }
    }
}
