using Cinema.Data.Entities;
using Cinema.Data.Enums;
using Cinema.Domain.Services.BaseService;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        Task<IEnumerable<Employee>> GetEmployeesByRoleAsync(EEmployeeRole role);
        Task<IEnumerable<Employee>> GetEmployeesByBirthDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}
