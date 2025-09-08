using HRPayrollManagementApi.Domain.Common;
using HRPayrollManagementApi.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HRPayrollManagement.Infrastructure.Persistence
{
    public  class AppDbContext(DbContextOptions<AppDbContext> options ): DbContext (options)
    {
        public DbSet<Employee> Employees => Set<Employee>();

        public override Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
            var utcNow = DateTime.UtcNow;
            foreach (var e in entries)
            {
                if (e.State == EntityState.Added)
                {
                    e.Entity.CreatedAt = utcNow;
                }
                if (e.State == EntityState.Modified)
                {
                    e.Entity.UpdatedAt = utcNow;
                }

            }
            return base.SaveChangesAsync(ct);
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(mb);
         
        }
    }
}
