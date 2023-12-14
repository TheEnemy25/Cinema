using Cinema.Infrastructure.Entities;
using Cinema.Infrastructure.Enums;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal sealed class SessionService : BaseService<Session>, ISessionService
    {
        private readonly ISessionPromoCodeService _promoCodeService;
        public SessionService(IBaseRepository<Session> repository, ISessionPromoCodeService promoCodeService) : base(repository)
        {
            _promoCodeService = promoCodeService;
        }

        public async Task<decimal> CalculateTicketPriceAsync(Guid sessionId, string promoCode = null)
        {
            var session = await _repository
               .Query()
               .Include(s => s.SessionSeats)
               .Include(s => s.Hall)
               .FirstOrDefaultAsync(s => s.Id == sessionId);

            if (session == null)
            {
                throw new InvalidOperationException("Session not found.");
            }

            int availableSeatsCount = session.SessionSeats.Count(ss => ss.Status == ESeatStatus.Available);

            decimal ticketPrice = session.Hall.BasePrice;

            if (!string.IsNullOrEmpty(promoCode))
            {
                decimal promoDiscount = await _promoCodeService.CalculateSessionDiscountAsync(promoCode, ticketPrice);
                ticketPrice -= promoDiscount;
            }

            return ticketPrice;
        }


        public async Task<int> GetAvailableSeatsCountAsync(Guid sessionId)
        {
            var session = await _repository
                .Query()
                .Include(s => s.SessionSeats)
                .FirstOrDefaultAsync(s => s.Id == sessionId);

            if (session == null)
            {
                throw new InvalidOperationException("Session not found.");
            }

            int availableSeatsCount = session.SessionSeats.Count(ss => ss.Status == ESeatStatus.Available);

            return availableSeatsCount;
        }

        public async Task<IEnumerable<Session>> GetSessionsByHallIdAsync(Guid hallId)
        {
            var sessions = await _repository
                .Query()
                .Where(s => s.Hall.Id == hallId)
                .ToListAsync();

            return sessions;
        }

        public async Task<IEnumerable<Session>> GetSessionsByMovieIdAsync(Guid movieId)
        {
            var sessions = await _repository
                .Query()
                .Where(s => s.Movie.Id == movieId)
                .ToListAsync();

            return sessions;
        }
    }
}
