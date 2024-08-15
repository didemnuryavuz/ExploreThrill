using ExploreThrill.Core.Entities.Abstract;
using ExploreThrill.Entities.Models.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExploreThrill.Entities.Configs.Concrete
{
    public class ReviewConfig : BaseConfig<Review, int>
    {
        public override void Configure(EntityTypeBuilder<Review> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Comment).HasMaxLength(1000);

            builder
                    .HasOne(x => x.Activity)
                    .WithMany(x => x.Reviews)
                    .HasForeignKey(x => x.ActivityId);



        }
    }
}
