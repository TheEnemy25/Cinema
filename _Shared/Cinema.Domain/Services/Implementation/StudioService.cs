using AutoMapper;
using Cinema.Data.Infrastructure;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal sealed class StudioService : BaseService<Studio, StudioDto>, IStudioService
    {
        private readonly IMapper _mapper;

        public StudioService(IBaseRepository<Studio> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<IEnumerable<StudioDto>> GetStudiosByMovieAsync(Guid movieId, CancellationToken cancellationToken = default)
        {
            var movies = await _repository
                .Query()
                .Where(s => s.MovieStudios.Any(ms => ms.Movie.Id == movieId))
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<StudioDto>>(movies);
        }
    }
}
