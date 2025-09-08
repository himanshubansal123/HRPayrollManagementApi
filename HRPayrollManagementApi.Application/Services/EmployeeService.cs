using HRPayrollManagementApi.Application.DTOs;
using HRPayrollManagementApi.Application.Interfaces.Common;
using HRPayrollManagementApi.Application.Interfaces.Employees;
using HRPayrollManagementApi.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPayrollManagementApi.Application.Services
{
    public class EmployeeService(IRepository<Employee> repo) : IEmployeeService
    {
        public async Task<Guid> CreateAsync(EmployeeDto entity, CancellationToken ct = default)
        {
            var e = new Employee
            {
                EmployeeCode = entity.EmployeeCode,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                JoinDate = entity.JoinDate,
                Salary = entity.Salary,
            };

            var created = await repo.AddAsync(e, ct);
            return created.ID;
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct = default)
        {
            var e = await repo.GetByIdAsync(id, ct) ?? throw new KeyNotFoundException("Employee Not Found");
            await repo.DeleteAsync(e, ct);
        }

        public async Task<IReadOnlyList<EmployeeDto>> GetAllAsync(CancellationToken ct = default)
        {
            var list = await repo.Query().AsNoTracking()
                .ToListAsync(ct);
            return list.Select(Map).ToList();
        }

        public async Task<EmployeeDto?> GetAsync(Guid id, CancellationToken ct = default)
        {
            var e = await repo.Query().AsNoTracking().FirstOrDefaultAsync(x => x.ID == id, ct);
            return e is null ? null : Map(e);
        }

        public async Task UpdateAsync(Guid id, EmployeeDto entity, CancellationToken ct = default)
        {
            var e = await repo.GetByIdAsync(id, ct) ?? throw new KeyNotFoundException("Employee Not Found");
            e.EmployeeCode = entity.EmployeeCode;
            e.FirstName = entity.FirstName;
            e.LastName = entity.LastName;
            e.Email = entity.Email;
            e.Salary = entity.Salary;
            e.JoinDate = entity.JoinDate;
            e.UpdatedAt = DateTime.UtcNow;
            await repo.UpdateAsync(e);
        }

        private static EmployeeDto Map(Employee e) =>
              new(e.ID, e.EmployeeCode, e.FirstName, e.LastName, e.Email, e.JoinDate, e.Salary);

      
    }
}
