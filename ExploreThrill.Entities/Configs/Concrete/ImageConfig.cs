using ExploreThrill.Core.Entities.Abstract;
using ExploreThrill.Entities.Models.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExploreThrill.Entities.Configs.Concrete
{
    public class ImageConfig : BaseConfig<Image, int>
    {
        public override void Configure(EntityTypeBuilder<Image> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                                   .HasMaxLength(300)
                                   .IsRequired();

            builder.Property(x => x.Path)
                                  .HasMaxLength(400)
                                  .IsRequired();

            builder.HasIndex(x => x.Path).IsUnique();

            builder
                    .HasOne(i => i.Activity)
                    .WithMany(i => i.Images)
                    .HasForeignKey(i => i.ActivityId);
        }
    }
}
