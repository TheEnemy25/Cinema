﻿using Cinema.Infrastructure.Entities;
using Cinema.Infrastructure.Enums;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal sealed class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        public EmployeeService(IBaseRepository<Employee> repository) : base(repository) { }

        public async Task<IEnumerable<Employee>> GetEmployeesByBirthDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _repository
                .Query()
                .Where(employee => employee.DateOfBirth >= startDate && employee.DateOfBirth <= endDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByRoleAsync(EEmployeeRole role)
        {
            return await _repository
                .Query()
                .Where(employee => employee.Role == role)
                .ToListAsync();
        }
    }
}
