using HRPayrollManagementApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HRPayrollManagementApi.Application.Interfaces.Common
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(Guid id,CancellationToken ct = default);
        Task<IReadOnlyList<T> > ListAsync(Expression <Func<T,bool>> ? predicate = null, CancellationToken ct = default);
        Task<T>AddAsync(T entity,CancellationToken ct = default);
        Task UpdateAsync(T entity, CancellationToken ct = default);
        Task DeleteAsync(T entity,CancellationToken ct = default);
        IQueryable<T> Query();
    }
}
