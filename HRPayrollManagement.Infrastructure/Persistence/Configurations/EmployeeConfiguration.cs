using HRPayrollManagementApi.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRPayrollManagementApi.Infrastructure.Persistence.Configurations
{
    public class EmployeeConfiguration :IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> b)
        {
          
            b.HasKey(x=> x.ID);
            b.Property(x => x.EmployeeCode).IsRequired().HasMaxLength(32);
            b.Property(x=> x.FirstName).IsRequired().HasMaxLength(100);
            b.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            b.Property(x => x.Email).IsRequired().HasMaxLength(200);
            b.Property(x => x.Salary).HasPrecision(18, 2);
            b.HasIndex(x => x.EmployeeCode).IsUnique();
            b.HasIndex(x=> x.Email).IsUnique();

        }
    }
}
