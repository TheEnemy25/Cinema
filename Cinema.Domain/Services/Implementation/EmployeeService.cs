using Cinema.Data.Entities;
using Cinema.Data.Enums;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;

namespace Cinema.Domain.Services.Implementation
{
    internal class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        public EmployeeService(IBaseRepository<Employee> repository) : base(repository)
        {
        }

        public Task<IEnumerable<Employee>> GetEmployeesByBirthDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetEmployeesByRoleAsync(EEmployeeRole role)
        {
            throw new NotImplementedException();
        }
    }
}
