using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Services.Implementation
{
    internal class CityService : BaseService<City>, ICityService
    {
        public CityService(IBaseRepository<City> repository) : base(repository)
        {
        }

        public Task<IEnumerable<City>> GetCitiesByCountryAsync(int countryId)
        {
            throw new NotImplementedException();
        }
    }
}
