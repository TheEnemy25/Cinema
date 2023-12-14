using Cinema.Infrastructure.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal class MovieService : BaseService<Movie>, IMovieService
    {
        public MovieService(IBaseRepository<Movie> repository) : base(repository)
        {
        }

        public async Task<IEnumerable<Movie>> GetMoviesByActorAsync(Guid actorId)
        {
            return await _repository
               .Query()
               .Where(movie => movie.MovieActors.Any(ma => ma.ActorId == actorId))
               .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetMoviesByCountryAsync(Guid countryId)
        {
            return await _repository
              .Query()
              .Where(movie => movie.MovieProductionCountries.Any(pc => pc.ProductionCountry.Id == countryId))
              .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetMoviesByDirectorAsync(Guid directorId)
        {
            return await _repository
                .Query()
                .Where(movie => movie.MovieDirectors.Any(md => md.Director.Id == directorId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetMoviesByGenreAsync(Guid genreId)
        {
            return await _repository
               .Query()
               .Where(movie => movie.MovieGenres.Any(mg => mg.Genre.Id == genreId))
               .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetMoviesReleasedThisYearAsync()
        {
            int currentYear = DateTime.Now.Year;

            return await _repository
                .Query()
                .Where(movie => movie.ReleaseDate.Year == currentYear)
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetTopRatedMoviesAsync(int count)
        {
            return await _repository
                .Query()
                .OrderByDescending(movie => movie.Rating)
                .Take(count)
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> SearchMoviesAsync(string query)
        {
            return await _repository
               .Query()
               .Where(movie => movie.Title.Contains(query) || movie.Description.Contains(query))
               .ToListAsync();
        }
    }
}
