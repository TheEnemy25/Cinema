using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;

namespace Cinema.Domain.Services.Implementation
{
    internal class DiscountService : BaseService<Discount>, IDiscountService
    {
        public DiscountService(IBaseRepository<Discount> repository) : base(repository)
        {
        }

        public Task<IEnumerable<Discount>> GetActiveDiscountsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Discount>> GetDiscountsByCinemaTheaterAsync(int cinemaTheaterId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Discount>> GetDiscountsByMovieAsync(int movieId)
        {
            throw new NotImplementedException();
        }
    }
}
