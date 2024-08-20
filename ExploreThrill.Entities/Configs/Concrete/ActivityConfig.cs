using ExploreThrill.Core.Entities.Abstract;
using ExploreThrill.Entities.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExploreThrill.Entities.Configs.Concrete
{
    public class ActivityConfig : BaseConfig<Activity, int>
    {
        public override void Configure(EntityTypeBuilder<Activity> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.ActivityName)
                                                 .HasMaxLength(100)
                                                 .IsRequired();

            builder.Property(x => x.Description)
                                                 .HasMaxLength(1000)
                                                 .IsRequired();

            builder.Property(a => a.Price).HasColumnType("decimal(18,2)");

            builder.HasData(
                            new Activity { Id = 1, ActivityName = "Paragliding", Description = "Fly over mountains", Capacity = 10, Price = 150.00M, ActivityDate = DateTime.UtcNow, CategoryId = 3, CompanyId = 1 },
                            new Activity { Id = 2, ActivityName = "Canoeing", Description = "Explore rivers", Capacity = 8, Price = 100.00M, ActivityDate = DateTime.UtcNow, CategoryId = 1, CompanyId = 4 },
                            new Activity { Id = 3, ActivityName = "Hot Air Ballooning", Description = "See the world from above", Capacity = 5, Price = 200.00M, ActivityDate = DateTime.UtcNow, CategoryId = 2, CompanyId = 2 },
                             new Activity
                             {
                                 Id = 4,
                                 ActivityName = "Scuba Diving",
                                 Description = "Explore the underwater world",
                                 Capacity = 10,
                                 Price = 250.00m,
                                 ActivityDate = new DateTime(2024, 08, 30),
                                 CategoryId = 1,
                                 CompanyId = 4
                             },
                                new Activity
                                {
                                    Id = 5,
                                    ActivityName = "Boat Tour",
                                    Description = "Explore the sea",
                                    Capacity = 5,
                                    Price = 250.00m,
                                    ActivityDate = new DateTime(2024, 08, 30),
                                    CategoryId = 5,
                                    CompanyId = 3
                                },
                                new Activity
                                {
                                    Id = 6,
                                    ActivityName = "Mountain Climbing",
                                    Description = "Conquer the peaks",
                                    Capacity = 5,
                                    Price = 300.00m,
                                    ActivityDate = new DateTime(2024, 09, 15),
                                    CategoryId = 2,
                                    CompanyId = 2
                                },
                                new Activity
                                {
                                    Id = 7,
                                    ActivityName = "Historical Tour",
                                    Description = "Discover the ancient ruins",
                                    Capacity = 20,
                                    Price = 150.00m,
                                    ActivityDate = new DateTime(2024, 10, 10),
                                    CategoryId = 4,
                                    CompanyId = 4
                                }

            );


        }
    }
}
