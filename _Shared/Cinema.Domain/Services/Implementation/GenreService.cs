using Cinema.Infrastructure.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal sealed class GenreService : BaseService<Genre>, IGenreService
    {
        public GenreService(IBaseRepository<Genre> repository) : base(repository) { }

        public async Task<Genre> GetGenreByNameAsync(string name)
        {
            var genre = await _repository
                 .Query()
                 .Where(genre => genre.Name == name)
                 .FirstOrDefaultAsync();

            return genre ?? new Genre();
        }

        public async Task<IEnumerable<Movie>> GetGenresByMovieAsync(Guid genreId)
        {
            var genreWithMovies = await _repository
                .Query(g => g.MovieGenres)
                .Where(g => g.Id == genreId)
                .FirstOrDefaultAsync();

            if (genreWithMovies != null)
            {
                var movies = genreWithMovies.MovieGenres.Select(mg => mg.Movie).ToList();
                return movies;
            }

            return Enumerable.Empty<Movie>();
        }
    }
}
