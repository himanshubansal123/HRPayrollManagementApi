using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPayrollManagementApi.Application.DTOs
{
    public record EmployeeDto
    (
    Guid ? Id,
    string EmployeeCode,
    string FirstName,
    string LastName,
    string Email,
    DateTime JoinDate,
    decimal Salary
    );
}
