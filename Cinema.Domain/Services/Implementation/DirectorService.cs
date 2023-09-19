using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;

namespace Cinema.Domain.Services.Implementation
{
    internal class DirectorService : BaseService<Director>, IDirectorService
    {
        public DirectorService(IBaseRepository<Director> repository) : base(repository)
        {
        }

        public Task<IEnumerable<Director>> GetDirectorsByCountryAsync(int countryId)
        {
            // return await _repository.Query().Where(director => director.CountryId == countryId).ToListAsync();
            throw new NotImplementedException(); 
        }

        public Task<IEnumerable<Director>> GetDirectorsByMovieAsync(int movieId)
        {
            // return await _repository.Query().Where(director => director.Movies.Any(movie => movie.Id == movieId)).ToListAsync();
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Director>> SearchDirectorsAsync(string query)
        {
            // return await _repository.Query().Where(director => director.Name.Contains(query)).ToListAsync();
            throw new NotImplementedException();
        }
    }
}