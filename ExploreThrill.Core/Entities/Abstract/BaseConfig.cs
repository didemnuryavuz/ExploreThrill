using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExploreThrill.Core.Entities.Abstract
{
    public abstract class BaseConfig<T, TId> : IEntityTypeConfiguration<T>
         where T : BaseEntity<TId>
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id);

        }
    }
}
