using Cinema.Domain.Services.BaseService;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IReviewService : IBaseService<Review, ReviewDto>
    {
        Task<IEnumerable<ReviewDto>> GetReviewsByMovieIdAsync(Guid movieId, CancellationToken cancellationToken = default);
        Task<double> GetAverageRatingByMovieIdAsync(Guid movieId, CancellationToken cancellationToken = default);
        Task<IEnumerable<ReviewDto>> GetRecentReviewsAsync(int count, CancellationToken cancellationToken = default);
        Task<IEnumerable<ReviewDto>> GetTopRatedReviewsAsync(int count, CancellationToken cancellationToken = default);
    }
}
