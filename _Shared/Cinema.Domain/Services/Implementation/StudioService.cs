using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal class StudioService : BaseService<Studio>, IStudioService
    {
        public StudioService(IBaseRepository<Studio> repository) : base(repository)
        {
        }

        public async Task<IEnumerable<Studio>> GetStudiosByMovieAsync(Guid movieId)
        {
            var movies = await _repository
                .Query()
                .Where(s => s.MovieStudios.Any(ms => ms.Movie.Id == movieId))
                .ToListAsync();

            return movies;
        }
    }
}
