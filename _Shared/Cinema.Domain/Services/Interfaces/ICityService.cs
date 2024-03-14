using Cinema.Domain.Services.BaseService;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Domain.Services.Interfaces
{
    public interface ICityService : IBaseService<City, CityDto>
    {
        Task<IEnumerable<CityDto>> GetCitiesByCountryAsync(Guid countryId, CancellationToken cancellationToken = default);
    }
}
