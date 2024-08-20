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

    }
}
