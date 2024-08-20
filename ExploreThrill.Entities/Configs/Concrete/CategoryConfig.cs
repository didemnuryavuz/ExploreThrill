using ExploreThrill.Core.Entities.Abstract;
using ExploreThrill.Entities.Models.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExploreThrill.Entities.Configs.Concrete
{
    public class CategoryConfig : BaseConfig<Category, int>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.CategoryName).HasMaxLength(50).IsRequired();
            builder.HasIndex(x => x.CategoryName).IsUnique();

            // Seed data
            builder.HasData(
                new Category { Id = 1, CategoryName = "Water Activity", CreateDate = DateTime.UtcNow },
                new Category { Id = 2, CategoryName = "Nature Activity", CreateDate = DateTime.UtcNow },
                new Category { Id = 3, CategoryName = "Adventure Activity", CreateDate = DateTime.UtcNow },
                new Category { Id = 4, CategoryName = "Culture Activity", CreateDate = DateTime.UtcNow },
                new Category { Id = 5, CategoryName = "Daily Activity", CreateDate = DateTime.UtcNow },
                new Category { Id = 6, CategoryName = "Workshop", CreateDate = DateTime.UtcNow }
            );
        }
    }
}
