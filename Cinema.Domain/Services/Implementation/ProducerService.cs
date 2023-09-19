using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;

namespace Cinema.Domain.Services.Implementation
{
    internal class ProducerService : BaseService<Producer>, IProducerService
    {
        public ProducerService(IBaseRepository<Producer> repository) : base(repository)
        {
        }

        public Task<IEnumerable<Producer>> GetProducersByMovieAsync(int movieId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Producer>> SearchProducersAsync(string query)
        {
            throw new NotImplementedException();
        }
    }
}
