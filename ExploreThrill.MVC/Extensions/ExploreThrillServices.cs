using ExploreThrill.BL.Abstract;
using ExploreThrill.BL.Concrete;
using ExploreThrill.Core.Business.Abstract;
using ExploreThrill.Core.Business.Concrete;
namespace ExploreThrill.MVC.Extensions
{
    public static class ExploreThrillServices
    {
        public static IServiceCollection AddExploreThrillServices(this IServiceCollection services)
        {

            services.AddScoped(typeof(IManager<,,>), typeof(Manager<,,>));

            services.AddScoped<IActivityManager, ActivityManager>();
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<ICityManager, CityManager>();
            services.AddScoped<ICompanyManager, CompanyManager>();
            services.AddScoped<IReviewManager, ReviewManager>();
            services.AddScoped<IImageManager, ImageManager>();
            //services.AddScoped<IUserManager, UserManager>();


            // Burasi Generic Manager siniflari cagirmak icin gereklidir
            // Eger Entity'mizin iş kurallari yoksa bu yapiyi direk kullanabiliriz
            //services.AddScoped(typeof(IManager<>), typeof(ManagerBase<>));

            return services;
        }
    }
}
