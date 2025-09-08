using HRPayrollManagementApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPayrollManagementApi.Application.Interfaces.Employees
{
    public interface IEmployeeService
    {
        Task<EmployeeDto?> GetAsync(Guid id, CancellationToken ct = default);
        Task<IReadOnlyList<EmployeeDto>> GetAllAsync(CancellationToken ct = default);
        Task<Guid> CreateAsync(EmployeeDto entity, CancellationToken ct = default);
        Task UpdateAsync(Guid id, EmployeeDto entity, CancellationToken ct = default);
        Task DeleteAsync(Guid id, CancellationToken ct = default);

    }
}
