using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using HRPayrollManagement.Infrastructure.Persistence;
using HRPayrollManagementApi.Application.Interfaces.Common;
using HRPayrollManagementApi.Infrastructure.Repositories;

namespace HRPayrollManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            var cs = config.GetConnectionString("DefaultConnection")
                     ?? throw new InvalidOperationException("Missing connection string 'DefaultConnection'.");

            services.AddDbContext<AppDbContext>(opt =>
                opt.UseSqlServer(cs, b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<EmployeeRepository>(); // optional specialized repo


            return services;
        }
    }
}

