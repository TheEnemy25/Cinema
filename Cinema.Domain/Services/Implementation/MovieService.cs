using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;

namespace Cinema.Domain.Services.Implementation
{
    internal class MovieService : BaseService<Movie>, IMovieService
    {
        public MovieService(IBaseRepository<Movie> repository) : base(repository)
        {
        }

        public Task<IEnumerable<Movie>> GetMoviesByActorAsync(int actorId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetMoviesByCountryAsync(int countryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetMoviesByDirectorAsync(int directorId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetMoviesByGenreAsync(int genreId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetMoviesReleasedThisYearAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetMoviesWithHighestGrossAsync(int count)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetTopRatedMoviesAsync(int count)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> SearchMoviesAsync(string query)
        {
            throw new NotImplementedException();
        }
    }
}
