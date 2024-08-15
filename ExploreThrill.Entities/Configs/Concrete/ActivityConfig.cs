using ExploreThrill.Core.Entities.Abstract;
using ExploreThrill.Entities.Models.Concrete;
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


        }
    }
}
