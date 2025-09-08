using HRPayrollManagement.Infrastructure.Persistence;
using HRPayrollManagementApi.Application.Interfaces.Common;
using HRPayrollManagementApi.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HRPayrollManagementApi.Infrastructure.Repositories
{
    public class Repository<T>(AppDbContext db) : IRepository<T> where T : BaseEntity
    {
        public async Task<T> AddAsync(T entity, CancellationToken ct = default)
        {
            db.Set<T>().Add(entity);
            await db.SaveChangesAsync(ct);
            return entity;
        }

        public async Task DeleteAsync(T entity, CancellationToken ct = default)
        {
            db.Set<T>().Remove(entity);
            await db.SaveChangesAsync(ct);
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken ct = default) => await db.Set<T>().FirstOrDefaultAsync(x=> x.ID == id, ct);
       

        public async Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken ct = default)
        {
            IQueryable<T> query = db.Set<T>().AsQueryable();
            if(predicate is not null) query = query.Where(predicate);
            return await query.ToListAsync();
        }

        public IQueryable<T> Query() => db.Set<T>().AsQueryable();
       

        public async Task UpdateAsync(T entity, CancellationToken ct = default)
        {
            db.Set<T>().Update(entity);
            await db.SaveChangesAsync(ct); 
        }
    }
}
