using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IDirectorService : IBaseService<Director>
    {
        Task<IEnumerable<Director>> GetDirectorsByMovieAsync(int movieId);
        Task<IEnumerable<Director>> SearchDirectorsAsync(string query);
        Task<IEnumerable<Director>> GetDirectorsByCountryAsync(int countryId);
    }
}
