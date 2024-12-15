using AutoMapper;
using Cinema.Data.Infrastructure;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal sealed class SessionPromoCodeService : BaseService<SessionPromoCode, SessionPromoCodeDto>, ISessionPromoCodeService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public SessionPromoCodeService(IBaseRepository<SessionPromoCode> repository, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(repository, mapper)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            Console.WriteLine("SessionPromoCodeService constructor called");
        }

        public async Task<decimal> CalculateSessionDiscountAsync(string promoCode, decimal originalPrice, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            if (user == null)
            {
                return 0;
            }

            bool hasUsedSessionPromoCode = await _repository
               .Query()
               .AnyAsync(spc => spc.PromoCode == promoCode && spc.UserSessionPromoCodes.Any(sessionCode => sessionCode.UserId == user.Id), cancellationToken);

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

                    // await _repository.AddAsync(promoCodeUsage);

                    return discountAmount;
                }
            }

            return 0;
        }


        public async Task<IEnumerable<SessionPromoCodeDto>> GetActiveSessionPromoCodesAsync(CancellationToken cancellationToken = default)
        {
            var activePromoCodes = await _repository
                .Query()
                .Where(spc => spc.MaxUsageCount > 0)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<SessionPromoCodeDto>>(activePromoCodes);
        }

        public async Task<IEnumerable<SessionPromoCodeDto>> GetAllValidSessionPromoCodesAsync(CancellationToken cancellationToken = default)
        {
            var validPromoCodes = await _repository
               .Query()
               .Where(spc => spc.MaxUsageCount > 0)
               .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<SessionPromoCodeDto>>(validPromoCodes);
        }

        public async Task<bool> IsSessionPromoCodeValidAsync(string promoCode, CancellationToken cancellationToken = default)
        {
            var isValid = await _repository
                .Query()
                .AnyAsync(spc => spc.PromoCode == promoCode && spc.MaxUsageCount > 0);

            return isValid;
        }
    }
}
