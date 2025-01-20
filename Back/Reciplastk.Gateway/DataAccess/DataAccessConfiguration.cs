using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Reciplastk.Gateway.DataAccess.Repositories;

namespace Reciplastk.Gateway.DataAccess
{
    public static class DataAccessConfiguration
    {
        public static IServiceCollection AddApplicationRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Employee>, BaseRepository<Employee>>();
            services.AddScoped<IBaseRepository<Role>, BaseRepository<Role>>();
            return services;
        }
        public static IServiceCollection AddApplicationDataAccess(this IServiceCollection services, ConfigurationManager config)
        {
            services.AddDbContext<ReciplastkContext>(options => options.UseNpgsql(config.GetConnectionString("ReciplastkContext")));
            return services;
        }
    }
}
