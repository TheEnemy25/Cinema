using AutoMapper;
using Cinema.Data.Infrastructure;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal sealed class MovieService : BaseService<Movie, MovieDto>, IMovieService
    {
        private readonly IMapper _mapper;

        public MovieService(IBaseRepository<Movie> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<IEnumerable<MovieDto>> GetMoviesByActorAsync(Guid actorId, CancellationToken cancellationToken)
        {
            var movie = await _repository
                .Query()
                .Where(m => m.MovieActors.Any(ma => ma.ActorId == actorId))
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<MovieDto>>(movie);
        }

        public async Task<IEnumerable<MovieDto>> GetMoviesByCountryAsync(Guid countryId, CancellationToken cancellationToken)
        {
            var movies = await _repository
                .Query()
                .Where(m => m.MovieProductionCountries.Any(mpc => mpc.ProductionCountry.Id == countryId))
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<MovieDto>>(movies);
        }

        public async Task<IEnumerable<MovieDto>> GetMoviesByDirectorAsync(Guid directorId, CancellationToken cancellationToken)
        {
            var movies = await _repository
                .Query()
                .Where(m => m.MovieDirectors.Any(md => md.DirectorId == directorId))
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<MovieDto>>(movies);
        }

        public async Task<IEnumerable<MovieDto>> GetMoviesByGenreAsync(Guid genreId, CancellationToken cancellationToken)
        {
            var movies = await _repository
                .Query()
                .Where(m => m.MovieGenres.Any(mg => mg.GenreId == genreId))
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<MovieDto>>(movies);
        }

        public async Task<IEnumerable<MovieDto>> GetMoviesReleasedThisYearAsync(CancellationToken cancellationToken)
        {
            int currentYear = DateTime.Now.Year;
            var movies = await _repository
                .Query()
                .Where(m => m.ReleaseDate.Year == currentYear)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<MovieDto>>(cancellationToken);
        }

        public async Task<IEnumerable<MovieDto>> GetTopRatedMoviesAsync(int count, CancellationToken cancellationToken)
        {
            var movies = await _repository
                .Query()
                .OrderByDescending(m => m.Rating)
                .Take(count)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<MovieDto>>(movies);
        }

        public async Task<IEnumerable<MovieDto>> SearchMoviesAsync(string query, CancellationToken cancellationToken)
        {
            var movies = await _repository
                .Query()
                .Where(m => m.Title.Contains(query) || m.Description.Contains(query))
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<MovieDto>>(movies);
        }
    }
}
