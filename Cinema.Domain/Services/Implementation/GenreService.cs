using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;

namespace Cinema.Domain.Services.Implementation
{
    internal class GenreService : BaseService<Genre>, IGenreService
    {
        public GenreService(IBaseRepository<Genre> repository) : base(repository)
        {
        }

        public Task<IEnumerable<Genre>> GetAllGenresAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Genre> GetGenreByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetMoviesByGenreAsync(Guid genreId)
        {
            throw new NotImplementedException();
        }
    }
}
