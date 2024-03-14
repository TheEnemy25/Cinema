using Cinema.Domain.Services.BaseService;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;
using Cinema.Infrastructure.Enums;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IEmployeeService : IBaseService<Employee, EmployeeDto>
    {
        Task<IEnumerable<EmployeeDto>> GetEmployeesByRoleAsync(EEmployeeRole role, CancellationToken cancellationToken = default);
        Task<IEnumerable<EmployeeDto>> GetEmployeesByBirthDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    }
}
