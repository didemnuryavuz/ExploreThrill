using ExploreThrill.Core.Entities.Abstract;
using ExploreThrill.Entities.Models.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExploreThrill.Entities.Configs.Concrete
{
    public class CompanyConfig : BaseConfig<Company, int>
    {
        public override void Configure(EntityTypeBuilder<Company> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.CompanyName)
                                           .HasMaxLength(50)
                                           .IsRequired();

            builder.HasIndex(x => x.CompanyName).IsUnique();

            builder.Property(x => x.Email)
                                          .HasMaxLength(100)
                                          .IsRequired();

            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Phone)
                                          .HasMaxLength(11)
                                          .IsRequired();

            builder.HasIndex(x => x.Phone).IsUnique();

            builder.Property(x => x.Website)
                                          .HasMaxLength(50)
                                          .IsRequired();

            builder.HasIndex(x => x.Website).IsUnique();

            builder.Property(x => x.Address).HasMaxLength(200);


            builder.Property(x => x.Description).HasMaxLength(250);


            // Seed data
            builder.HasData(
                new Company
                {
                    Id = 1,
                    CompanyName = "Turkish Travel",
                    Description = "Leading travel company in Turkey",
                    Email = "info@turkishtravel.com",
                    Phone = "00321234567",
                    Website = "www.turkishtravel.com",
                    Address = "Istanbul, Turkey",
                    CreateDate = DateTime.UtcNow
                },
                new Company
                {
                    Id = 2,
                    CompanyName = "Anatolia Adventures",
                    Description = "Discover the beauty of Anatolia",
                    Email = "contact@anatoliaadventures.com",
                    Phone = "00337654321",
                    Website = "www.anatoliaadventures.com",
                    Address = "Ankara, Turkey",
                    CreateDate = DateTime.UtcNow
                },
                new Company
                {
                    Id = 3,
                    CompanyName = "Ege Tours",
                    Description = "Explore the Aegean coast",
                    Email = "support@egetours.com",
                    Phone = "00339876543",
                    Website = "www.egetours.com",
                    Address = "Izmir, Turkey",
                    CreateDate = DateTime.UtcNow
                },
                new Company
                {
                    Id = 4,
                    CompanyName = "Antalya Getaways",
                    Description = "Your guide to Antalya",
                    Email = "info@antalyagetaways.com",
                    Phone = "00335432123",
                    Website = "www.antalyagetaways.com",
                    Address = "Antalya, Turkey",
                    CreateDate = DateTime.UtcNow

                },
                new Company
                {
                    Id = 5,
                    CompanyName = "Mardin Travels",
                    Description = "Experience the historical city of Mardin",
                    Email = "info@mardintravels.com",
                    Phone = "00332109876",
                    Website = "www.mardintravels.com",
                    Address = "Mardin, Turkey",
                    CreateDate = DateTime.UtcNow
                }
            );
        }
    }
}
