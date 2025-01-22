using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Repositories;

namespace RecuperApp.Domain.Configurations
{
    public static class DataAccessConfiguration
    {
        public static IServiceCollection AddApplicationRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Employee>, BaseRepository<Employee>>();
            services.AddScoped<IBaseRepository<Role>, BaseRepository<Role>>();
            return services;
        }
        public static IServiceCollection AddApplicationDataAccess(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ReciplastkContext>(options => options.UseNpgsql(config.GetConnectionString("RecuperAppContext")).UseLowerCaseNamingConvention());
            return services;
        }

        public static void RunApplicationMigrations(this IHost app)
        {

            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ReciplastkContext>();
            db.Database.Migrate();
        }
    }
}
