using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;

namespace Cinema.Domain.Services.Interfaces
{
    public interface ICityService : IBaseService<City>
    {
        Task<IEnumerable<City>> GetCitiesByCountryAsync(Guid countryId);
    }
}
