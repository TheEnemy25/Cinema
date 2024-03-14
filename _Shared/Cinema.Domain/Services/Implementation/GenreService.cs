using AutoMapper;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal sealed class GenreService : BaseService<Genre, GenreDto>, IGenreService
    {
        private readonly IMapper _mapper;

        public GenreService(IBaseRepository<Genre> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<GenreDto> GetGenreByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            var genre = await _repository
                 .Query()
                 .Where(g => g.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                 .FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map<GenreDto>(genre);
        }

        public async Task<IEnumerable<MovieDto>> GetGenresByMovieAsync(Guid genreId, CancellationToken cancellationToken = default)
        {
            var genre = await _repository
                .Query()
                .Where(g => g.MovieGenres.Any(mg => mg.MovieId == genreId))
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<MovieDto>>(genre);
        }
    }
}
