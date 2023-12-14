using Cinema.Infrastructure.Entities;
using Cinema.Domain.Services.BaseService;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IReviewService : IBaseService<Review>
    {
        Task<IEnumerable<Review>> GetReviewsByMovieIdAsync(Guid movieId);
        Task<double> GetAverageRatingByMovieIdAsync(Guid movieId);
        Task<IEnumerable<Review>> GetRecentReviewsAsync(int count);
        Task<IEnumerable<Review>> GetTopRatedReviewsAsync(int count);
    }
}
