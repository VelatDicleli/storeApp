using Microsoft.EntityFrameworkCore;
using StoreApp.Business.Abstract;
using StoreApp.Business.Concrete;
using StoreApp.DataAccess.GenericRepo.Concrete;
using StoreApp.Entities.Models;
using StoreApp.Models;
using System.Configuration;
using StoreApp.DataAccess.GenericRepo.Absract;
using StoreApp.DataAccess.Abstract;
using StoreApp.DataAccess.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;


namespace StoreApp.Infrastructer.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("msSqlconnection"),
                
                    
                    sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly("StoreApp");
                    //sqlOptions.EnableRetryOnFailure(
                    //maxRetryCount: 5, // Maksimum deneme sayısı
                    //maxRetryDelay: TimeSpan.FromSeconds(30), // Her deneme arasındaki maksimum bekleme süresi
                    //errorNumbersToAdd: null // Özel hata numaraları (isteğe bağlı)

                //);

                }


                );

                
                options.EnableSensitiveDataLogging(); // Hassas veri günlüğü etkinleştirildi.
            });

        }
        
        

        public static void ConfigureSession(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = "StoreApp.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<Cart>(c => SessionCart.getCart(c));
        }

        public static void ConfigureRepositoryRegistration(this IServiceCollection services)
        {
            services.AddScoped<IRepoManager, RepoManager>();
            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<IOrderDal, EfOrderDal>();
        }

        public static void ConfigureServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IAuthService, AuthManager>();
            
        }

        public static void ConfigureRouting(this IServiceCollection services)
        {
            services.AddRouting(options => { 
                options.LowercaseUrls = true;
                
            });
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(options => 
            {
                options.SignIn.RequireConfirmedEmail = false;
                options.User.RequireUniqueEmail = false;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                
                
                }).AddEntityFrameworkStores<RepositoryContext>();
        }

        public static void ConfigureApplicationCookie(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/Account/Login");
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                options.AccessDeniedPath = new PathString("/Account/AccessDenied");
            });
        }

    }
}
