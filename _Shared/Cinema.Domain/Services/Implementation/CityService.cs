using AutoMapper;
using Cinema.Data.Infrastructure;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal sealed class CityService : BaseService<City, CityDto>, ICityService
    {
        private readonly IMapper _mapper;

        public CityService(IBaseRepository<City> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<IEnumerable<CityDto>> GetCitiesByCountryAsync(Guid countryId, CancellationToken cancellationToken = default)
        {
            var city = await _repository
                .Query()
                .Where(c => c.CountryId == countryId)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<CityDto>>(city);
        }
    }
}
