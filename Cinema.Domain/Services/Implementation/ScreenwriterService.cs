using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal class ScreenwriterService : BaseService<Screenwriter>, IScreenwriterService
    {
        public ScreenwriterService(IBaseRepository<Screenwriter> repository) : base(repository)
        {
        }

        public async Task<IEnumerable<Screenwriter>> GetScreenwritersByMovieAsync(Guid movieId)
        {
            var screenwriters = await _repository
                .Query()
                .Where(s => s.MovieScreenwriters.Any(ms => ms.Movie.Id == movieId))
                .ToListAsync();

            return screenwriters;
        }

        public async Task<IEnumerable<Screenwriter>> SearchScreenwritersAsync(string query)
        {
            var screenwriters = await _repository
                .Query()
                .Where(s => s.FullName.Contains(query) || s.Biography.Contains(query))
                .ToListAsync();

            return screenwriters;
        }
    }
}
