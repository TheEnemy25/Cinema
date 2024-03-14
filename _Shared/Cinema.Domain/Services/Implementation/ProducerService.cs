using AutoMapper;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal sealed class ProducerService : BaseService<Producer, ProducerDto>, IProducerService
    {
        private readonly IMapper _mapper;

        public ProducerService(IBaseRepository<Producer> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<IEnumerable<ProducerDto>> GetProducersByMovieAsync(Guid movieId, CancellationToken cancellationToken)
        {
            var producers = await _repository
               .Query()
               .Where(p => p.MovieProducers.Any(mp => mp.MovieId == movieId))
               .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ProducerDto>>(producers);
        }

        public async Task<IEnumerable<ProducerDto>> SearchProducersAsync(string query, CancellationToken cancellationToken)
        {
            var producers = await _repository
                .Query()
                .Where(p => p.FullName.Contains(query) || p.Biography.Contains(query))
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ProducerDto>>(producers);
        }
    }
}
