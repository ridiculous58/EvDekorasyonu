using EvDekorasyonu.Application.Interfaces;
using EvDekorasyonu.Persistence.Repositories;
using EvDekorasyonu.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EvDekorasyonu.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase("TestDb");
                //options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IDekorService, DekorService>();
            services.AddScoped<IDekorCategoryService, DekorCategoryService>();
        }

    }
}
