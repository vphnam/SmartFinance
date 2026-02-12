using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Domain.Shared.Base
{
    public interface IRepository<T> where T : EntityBase<Guid>
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);

        IQueryable<T> GetQueryable(Expression<Func<T, bool>> predicate = null);

        Task<T> FindAsync(string id);
        Task<T> FindByExpressionAsync(Expression<Func<T, bool>> predicate);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<bool> IsAnyAsync(Expression<Func<T, bool>> predicate);

    }
}
