using Cinema.Infrastructure.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal class ReviewService : BaseService<Review>, IReviewService
    {
        public ReviewService(IBaseRepository<Review> repository) : base(repository)
        {
        }

        public async Task<double> GetAverageRatingByMovieIdAsync(Guid movieId)
        {
            var reviews = await _repository
                .Query()
                .Where(r => r.MovieId == movieId)
                .ToListAsync();

            if(reviews.Any())
            {
                double averageRating = reviews.Average(r => r.Rating);
                return averageRating;
            }
            else return 0;
        }

        public async Task<IEnumerable<Review>> GetRecentReviewsAsync(int count)
        {
            var reviews = await _repository
                .Query()
                .OrderByDescending(r => r.Rating)
                .Take(count)
                .ToListAsync();

            return reviews;
        }

        public async Task<IEnumerable<Review>> GetReviewsByMovieIdAsync(Guid movieId)
        {
            var reviews = await _repository
                .Query()
                .Where(r => r.MovieId == movieId)
                .ToListAsync();

            return reviews;
        }

        public async Task<IEnumerable<Review>> GetTopRatedReviewsAsync(int count)
        {
            var reviews = await _repository
                .Query()
                .OrderByDescending(r => r.Rating)
                .Take(count)
                .ToListAsync();

            return reviews;
        }
    }
}
