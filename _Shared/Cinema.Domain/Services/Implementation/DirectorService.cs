using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal class DirectorService : BaseService<Director>, IDirectorService
    {
        public DirectorService(IBaseRepository<Director> repository) : base(repository)
        {
        }

        public async Task<IEnumerable<Director>> GetDirectorsByMovieAsync(Guid movieId)
        {
            return await _repository
                .Query()
                .Where(director => director.MovieDirectors.Any(movieDirector => movieDirector.MovieId == movieId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Director>> SearchDirectorsAsync(string query)
        {
            return await _repository
                .Query()
                .Where(director => director.FullName.Contains(query))
                .ToListAsync();
        }
    }
}