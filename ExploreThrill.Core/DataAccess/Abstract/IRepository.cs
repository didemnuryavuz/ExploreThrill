using ExploreThrill.Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExploreThrill.Core.DataAccess.Abstract
{
    public interface IRepository<T, TId, TContext>
        where T : BaseEntity<TId>
        where TContext : DbContext, new()
    {

        public Task<int> AddAsync(T entity);
        public Task<int> UpdateAsync(T entity);
        public Task<int> DeleteAsync(T entity);
        public Task<T?> GetByAsync(Expression<Func<T, bool>>? filter);
        public Task<T?> FindAsync(TId id);
        public Task<IEnumerable<T>?> GetAllAsync(Expression<Func<T, bool>>? filter);
        public Task<IEnumerable<T>?> GetAllIncludeAsync(
            Expression<Func<T, bool>>? filter,
            params Expression<Func<T, object>>[] include);
        public Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<TId> ids);
    }
}
