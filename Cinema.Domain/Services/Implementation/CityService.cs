using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal class CityService : BaseService<City>, ICityService
    {
        public CityService(IBaseRepository<City> repository) : base(repository)
        {
        }

        public async Task<IEnumerable<City>> GetCitiesByCountryAsync(Guid countryId)
        {
            return await _repository
                .Query()
                .Where(city => city.CountryId == countryId)
                .ToListAsync();
        }
    }
}
