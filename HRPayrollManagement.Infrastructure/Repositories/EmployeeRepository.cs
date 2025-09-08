using HRPayrollManagement.Infrastructure.Persistence;
using HRPayrollManagementApi.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPayrollManagementApi.Infrastructure.Repositories
{
    public class EmployeeRepository(AppDbContext db)
    {
        public Task<Employee?>FindByEmployeeCodeAsync(string empoloyeeCode, CancellationToken ct = default) =>
            db.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.EmployeeCode == empoloyeeCode, ct);

        
    }
}
