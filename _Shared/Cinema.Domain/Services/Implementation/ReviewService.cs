using AutoMapper;
using Cinema.Data.Infrastructure;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal sealed class ReviewService : BaseService<Review, ReviewDto>, IReviewService
    {
        private readonly IMapper _mapper;

        public ReviewService(IBaseRepository<Review> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<double> GetAverageRatingByMovieIdAsync(Guid movieId, CancellationToken cancellationToken = default)
        {
            var reviews = await _repository
                .Query()
                .Where(r => r.Movie.Id == movieId)
                .ToListAsync(cancellationToken);

            if (reviews.Any())
            {
                double averageRating = reviews.Average(r => r.Rating);
                return averageRating;
            }
            else return 0;
        }

        public async Task<IEnumerable<ReviewDto>> GetRecentReviewsAsync(int count, CancellationToken cancellationToken = default)
        {
            var reviews = await _repository
                .Query()
                .OrderByDescending(r => r.Rating)
                .Take(count)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ReviewDto>>(reviews);
        }

        public async Task<IEnumerable<ReviewDto>> GetReviewsByMovieIdAsync(Guid movieId, CancellationToken cancellationToken = default)
        {
            var reviews = await _repository
                .Query()
                .Where(r => r.Movie.Id == movieId)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ReviewDto>>(reviews);
        }

        public async Task<IEnumerable<ReviewDto>> GetTopRatedReviewsAsync(int count, CancellationToken cancellationToken = default)
        {
            var reviews = await _repository
                .Query()
                .OrderByDescending(r => r.Rating)
                .Take(count)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ReviewDto>>(reviews);
        }
    }
}
