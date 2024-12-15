using AutoMapper;
using Cinema.Data.Infrastructure;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;
using Cinema.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal sealed class SessionService : BaseService<Session, SessionDto>, ISessionService
    {
        private readonly ISessionPromoCodeService _promoCodeService;
        private readonly IMapper _mapper;

        public SessionService(IBaseRepository<Session> repository, ISessionPromoCodeService promoCodeService, IMapper mapper) : base(repository, mapper)
        {
            _promoCodeService = promoCodeService;
        }

        public async Task<decimal> CalculateTicketPriceAsync(Guid sessionId, string promoCode = null, CancellationToken cancellationToken = default)
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


        public async Task<int> GetAvailableSeatsCountAsync(Guid sessionId, CancellationToken cancellationToken = default)
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

        public async Task<IEnumerable<SessionDto>> GetSessionsByHallIdAsync(Guid hallId, CancellationToken cancellationToken = default)
        {
            var sessions = await _repository
                .Query()
                .Where(s => s.Hall.Id == hallId)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<SessionDto>>(sessions);
        }

        public async Task<IEnumerable<SessionDto>> GetSessionsByMovieIdAsync(Guid movieId, CancellationToken cancellationToken = default)
        {
            var sessions = await _repository
                .Query()
                .Where(s => s.Movie.Id == movieId)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<SessionDto>>(sessions);
        }
    }
}
