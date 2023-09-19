using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;

namespace Cinema.Domain.Services.Implementation
{
    internal class SessionService : BaseService<Session>, ISessionService
    {
        public SessionService(IBaseRepository<Session> repository) : base(repository)
        {
        }

        public Task<decimal> CalculateTicketPriceAsync(Guid sessionId, string promoCode = null)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetAvailableSeatsCountAsync(Guid sessionId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Session>> GetSessionsByHallIdAsync(Guid hallId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Session>> GetSessionsByMovieIdAsync(Guid movieId)
        {
            throw new NotImplementedException();
        }
    }
}
