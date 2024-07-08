using AutoMapper;
using Cinema.Data.Infrastructure;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal sealed class ScreenwriterService : BaseService<Screenwriter, ScreenwriterDto>, IScreenwriterService
    {
        private readonly IMapper _mapper;

        public ScreenwriterService(IBaseRepository<Screenwriter> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<IEnumerable<ScreenwriterDto>> GetScreenwritersByMovieAsync(Guid movieId, CancellationToken cancellationToken = default)
        {
            var screenwriters = await _repository
                .Query()
                .Where(s => s.MovieScreenwriters.Any(ms => ms.Movie.Id == movieId))
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ScreenwriterDto>>(screenwriters);
        }

        public async Task<IEnumerable<ScreenwriterDto>> SearchScreenwritersAsync(string query, CancellationToken cancellationToken = default)
        {
            var screenwriters = await _repository
                .Query()
                .Where(s => s.FullName.Contains(query) || s.Biography.Contains(query))
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ScreenwriterDto>>(screenwriters);
        }
    }
}
