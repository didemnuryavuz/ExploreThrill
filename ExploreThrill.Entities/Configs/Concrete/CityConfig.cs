using ExploreThrill.Core.Entities.Abstract;
using ExploreThrill.Entities.Models.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExploreThrill.Entities.Configs.Concrete
{
    public class CityConfig : BaseConfig<City, int>
    {
        public override void Configure(EntityTypeBuilder<City> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name).HasMaxLength(20).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();

            // Seed data

            builder.HasData(
                new City { Id = 1, Name = "İstanbul", CreateDate = DateTime.UtcNow },
                new City { Id = 2, Name = "Ankara", CreateDate = DateTime.UtcNow },
                new City { Id = 3, Name = "İzmir", CreateDate = DateTime.UtcNow },
                new City { Id = 4, Name = "Antalya", CreateDate = DateTime.UtcNow },
                new City { Id = 5, Name = "Bursa", CreateDate = DateTime.UtcNow },
                new City { Id = 6, Name = "Kastamonu", CreateDate = DateTime.UtcNow },
                new City { Id = 7, Name = "Rize", CreateDate = DateTime.UtcNow },
                new City { Id = 8, Name = "Gaziantep", CreateDate = DateTime.UtcNow },
                new City { Id = 9, Name = "Şanlıurfa", CreateDate = DateTime.UtcNow },
                new City { Id = 10, Name = "Mardin", CreateDate = DateTime.UtcNow }
            );
        }
    }
}
