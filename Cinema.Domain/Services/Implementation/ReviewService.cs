using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;

namespace Cinema.Domain.Services.Implementation
{
    internal class ReviewService : BaseService<Review>, IReviewService
    {
        public ReviewService(IBaseRepository<Review> repository) : base(repository)
        {
        }

        public Task<double> GetAverageRatingByMovieIdAsync(Guid movieId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Review>> GetRecentReviewsAsync(int count)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Review>> GetReviewsByMovieIdAsync(Guid movieId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Review>> GetTopRatedReviewsAsync(int count)
        {
            throw new NotImplementedException();
        }
    }
}
