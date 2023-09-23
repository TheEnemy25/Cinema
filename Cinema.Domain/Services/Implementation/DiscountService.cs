using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal class DiscountService : BaseService<Discount>, IDiscountService
    {
        public DiscountService(IBaseRepository<Discount> repository) : base(repository)
        {
        }

        public async Task<IEnumerable<Discount>> GetActiveDiscountsAsync()
        {
            var currentDate = DateTime.Now;

            return await _repository
                .Query()
                .Where(discount => discount.StartDate <= currentDate && discount.EndDate >= currentDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Discount>> GetDiscountsBySessionAsync(Guid sessionId)
        {
            return await _repository
                .Query()
                .Where(discount => discount.Sessions.Any(session => session.Id == sessionId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Discount>> GetDiscountsByMovieAsync(Guid movieId)
        {
            return await _repository
                .Query()
                .Where(discount => discount.Sessions.Any(session => session.MovieId == movieId))
                .ToListAsync();
        }
    }
}
