using ExploreThrill.Core.DataAccess.Abstract;
using ExploreThrill.Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ExploreThrill.Core.Business.Abstract
{
    public interface IManager<T, TId, TContext> : IRepository<T, TId, TContext>
        where T : BaseEntity<TId>
        where TContext : DbContext, new()
    {

    }
}
