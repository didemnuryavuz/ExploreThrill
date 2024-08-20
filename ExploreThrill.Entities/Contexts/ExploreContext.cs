using ExploreThrill.Core.Entities.Concrete;
using ExploreThrill.Entities.Models.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ExploreThrill.Entities.Contexts
{
    public class ExploreContext : IdentityDbContext<MyUser, IdentityRole, string>
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }

        public ExploreContext()
        {

        }

        public ExploreContext(DbContextOptions<ExploreContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ExploreThrill;Trusted_Connection=true;TrustServerCertificate=true").EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //Identity Paketi İcin

            #region N-N Fluent API

            // Activity ve City arasındaki çoktan çoğa ilişki
            modelBuilder.Entity<Activity>()
                .HasMany(a => a.Cities)
                .WithMany(c => c.Activities)
                .UsingEntity<Dictionary<string, object>>(
                    "ActivityCity",
                    j => j.HasOne<City>().WithMany().HasForeignKey("CityId"),
                    j => j.HasOne<Activity>().WithMany().HasForeignKey("ActivityId")
                );

            modelBuilder.Entity("ActivityCity").HasData(
                new { ActivityId = 1, CityId = 1 },
                new { ActivityId = 1, CityId = 4 },
                new { ActivityId = 2, CityId = 3 },
                new { ActivityId = 3, CityId = 9 },
                new { ActivityId = 4, CityId = 4 },
                new { ActivityId = 5, CityId = 4 },
                new { ActivityId = 5, CityId = 2 },
                new { ActivityId = 6, CityId = 9 },
                new { ActivityId = 6, CityId = 6 },
                new { ActivityId = 7, CityId = 1 },
                new { ActivityId = 7, CityId = 10 }
            );

            #endregion

            #region Admin Oluşturma
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "99c113c8-3358-4c3f-b376-d16ae29476b8",// Belirli bir Id vermek isteyebilirsiniz
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            // Admin Kullanıcı Ekleme
            var hasher = new PasswordHasher<MyUser>();

            modelBuilder.Entity<MyUser>().HasData(new MyUser
            {
                Id = "99c113c8-3358-4c3f-b376-d16ae2947611", // Belirli bir Id vermek isteyebilirsiniz
                UserName = "admin@admin.com",
                NormalizedUserName = "admin@admin.com",
                Email = "admin@admin.com",
                NormalizedEmail = "admin@admin.com",
                EmailConfirmed = true,
                TcNo = "12345678955",
                PasswordHash = hasher.HashPassword(null, "Admin@1234"),
                SecurityStamp = string.Empty
            });

            // Admin Kullanıcıya Rol Ekleme
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "99c113c8-3358-4c3f-b376-d16ae29476b8",
                UserId = "99c113c8-3358-4c3f-b376-d16ae2947611"
            });
            #endregion


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }


    }
}
