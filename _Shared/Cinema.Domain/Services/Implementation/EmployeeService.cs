using AutoMapper;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;
using Cinema.Infrastructure.Enums;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal sealed class EmployeeService : BaseService<Employee, EmployeeDto>, IEmployeeService
    {
        private readonly IMapper _mapper;

        public EmployeeService(IBaseRepository<Employee> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesByBirthDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
        {
            var employee = await _repository
                .Query()
                .Where(e => e.DateOfBirth >= startDate && e.DateOfBirth <= endDate)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<EmployeeDto>>(employee);
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesByRoleAsync(EEmployeeRole role, CancellationToken cancellationToken = default)
        {
            var employee = await _repository
                .Query()
                .Where(e => e.Role == role)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<EmployeeDto>>(employee);
        }
    }
}
