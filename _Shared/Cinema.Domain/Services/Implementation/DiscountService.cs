using AutoMapper;
using Cinema.Data.Infrastructure;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal sealed class DiscountService : BaseService<Discount, DiscountDto>, IDiscountService
    {
        private readonly IMapper _mapper;

        public DiscountService(IBaseRepository<Discount> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<IEnumerable<DiscountDto>> GetActiveDiscountsAsync(CancellationToken cancellationToken)
        {
            var currentDate = DateTime.Now;
            var activeDiscount = await _repository
                .Query()
                .Where(d => d.StartDate <= currentDate && d.EndDate >= currentDate)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<DiscountDto>>(activeDiscount);
        }

        public async Task<IEnumerable<DiscountDto>> GetDiscountsBySessionAsync(Guid sessionId, CancellationToken cancellationToken)
        {
            var discount = await _repository
                .Query()
                .Where(d => d.Sessions.Any(s => s.Id == sessionId))
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<DiscountDto>>(discount);
        }

        public async Task<IEnumerable<DiscountDto>> GetDiscountsByMovieAsync(Guid movieId, CancellationToken cancellationToken)
        {
            var discount = await _repository
                .Query()
                .Where(d => d.Sessions.Any(s => s.MovieId == movieId))
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<DiscountDto>>(discount);
        }
    }
}
