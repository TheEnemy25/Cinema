using AutoMapper;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal sealed class DirectorService : BaseService<Director, DirectorDto>, IDirectorService
    {
        private readonly IMapper _mapper;

        public DirectorService(IBaseRepository<Director> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<IEnumerable<DirectorDto>> GetDirectorsByMovieAsync(Guid movieId, CancellationToken cancellationToken = default)
        {
            var director = _repository
                .Query()
                .Where(d => d.MovieDirectors.Any(md => md.MovieId == movieId))
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<DirectorDto>>(director);
        }

        public async Task<IEnumerable<DirectorDto>> SearchDirectorsAsync(string query, CancellationToken cancellationToken = default)
        {
            var director = await _repository
                .Query()
                .Where(d => d.FullName.Contains(query))
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<DirectorDto>>(director);
        }
    }
}