using ExploreThrill.Core.Entities.Concrete;
using ExploreThrill.Entities.Contexts;
using ExploreThrill.MVC.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ExploreThrill.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Connection String'i appsettings.json dosyasýndan çeker
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ExploreContext>(options =>
                options.UseSqlServer(connectionString));

            // Diðer servisleri ekle
            builder.Services.AddExploreThrillServices();

            //Ýdentity ekle
            builder.Services.AddIdentity<MyUser, IdentityRole>()
                .AddEntityFrameworkStores<ExploreContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddRazorPages();


            var app = builder.Build();

            //// Rolleri ve Admin kullanýcýyý seed et
            //using (var scope = app.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    SeedRolesAndAdminUser(services).Wait();
            //}


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Authentication ve Authorization middleware'lerini ekleyin
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
        public static async Task SeedRolesAndAdminUser(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<MyUser>>();

            string[] roleNames = { "Admin", "User" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Admin kullanýcýsýný oluþtur
            var adminUser = new MyUser
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com"
            };

            string adminPassword = "Admin123!";
            var user = await userManager.FindByEmailAsync("admin@admin.com");

            if (user == null)
            {
                var createAdminUser = await userManager.CreateAsync(adminUser, adminPassword);
                if (createAdminUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }

    }
}
