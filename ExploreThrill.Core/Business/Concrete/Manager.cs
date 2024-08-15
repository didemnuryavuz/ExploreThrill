using ExploreThrill.Core.Business.Abstract;
using ExploreThrill.Core.DataAccess.Concrete;
using ExploreThrill.Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ExploreThrill.Core.Business.Concrete
{
    public class Manager<T, TId, TContext> : Repository<T, TId, TContext>, IManager<T, TId, TContext>
        where T : BaseEntity<TId>
        where TContext : DbContext, new()
    {
        public readonly TContext context;

        public Manager(TContext context) : base(context)
        {
            this.context = context;
        }
    }
}
