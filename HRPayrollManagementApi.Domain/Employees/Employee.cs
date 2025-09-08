using HRPayrollManagementApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPayrollManagementApi.Domain.Employees
{
    public class Employee :BaseEntity
    {

        public string EmployeeCode { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public DateTime JoinDate { get; set; }
        public decimal Salary { get; set; }
    }
}
