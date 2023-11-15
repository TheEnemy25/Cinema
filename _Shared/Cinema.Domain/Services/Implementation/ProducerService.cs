using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal class ProducerService : BaseService<Producer>, IProducerService
    {
        public ProducerService(IBaseRepository<Producer> repository) : base(repository)
        {
        }

        public async Task<IEnumerable<Producer>> GetProducersByMovieAsync(Guid movieId)
        {
            var producers = await _repository
               .Query()
               .Where(p => p.MovieProducers.Any(mp => mp.Movie.Id == movieId))
               .ToListAsync();

            return producers;
        }

        public async Task<IEnumerable<Producer>> SearchProducersAsync(string query)
        {
            var producers = await _repository
                .Query()
                .Where(p => p.FullName.Contains(query) || p.Biography.Contains(query))
                .ToListAsync();

            return producers;
        }
    }
}
