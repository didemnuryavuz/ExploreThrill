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
                new Category { Id = 1, CategoryName = "Su Sporları", CreateDate = DateTime.UtcNow },
                new Category { Id = 2, CategoryName = "Doğa Etkinlikleri", CreateDate = DateTime.UtcNow },
                new Category { Id = 3, CategoryName = "Adrenalin Etkinlikleri", CreateDate = DateTime.UtcNow },
                new Category { Id = 4, CategoryName = "Kültürel Etkinlikler", CreateDate = DateTime.UtcNow },
                new Category { Id = 5, CategoryName = "Günübirlik Etkinlikler", CreateDate = DateTime.UtcNow },
                new Category { Id = 6, CategoryName = "Atölyeler", CreateDate = DateTime.UtcNow }
            );
        }
    }
}
