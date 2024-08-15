using ExploreThrill.Core.DataAccess.Abstract;
using ExploreThrill.Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExploreThrill.Core.DataAccess.Concrete
{
    public abstract class Repository<T, TId, TContext> : IRepository<T, TId, TContext>
        where T : BaseEntity<TId>
        where TContext : DbContext, new()
    {
        protected readonly TContext context;

        public Repository(TContext context)
        {
            this.context = context;
        }

        public virtual async Task<int> AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            return await context.SaveChangesAsync();
        }

        public virtual async Task<int> UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
            return await context.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            return await context.SaveChangesAsync();
        }

        public virtual async Task<T?> FindAsync(TId id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>?> GetAllAsync(Expression<Func<T, bool>>? filter)
        {
            if (filter == null)
            {
                return await context.Set<T>().ToListAsync();
            }
            else
            {
                return await context.Set<T>().Where(filter).ToListAsync();
            }
        }

        public virtual async Task<T?> GetByAsync(Expression<Func<T, bool>>? filter)
        {
            if (filter == null)
            {
                return await context.Set<T>().FirstOrDefaultAsync();
            }
            else
            {
                return await context.Set<T>().Where(filter).FirstOrDefaultAsync();
            }
        }

        public virtual async Task<IEnumerable<T>> GetAllIncludeAsync(Expression<Func<T, bool>>? filter, params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await include.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<TId> ids)
        {
            return await context.Set<T>().Where(entity => ids.Contains(entity.Id)).ToListAsync();
        }

    }
}
