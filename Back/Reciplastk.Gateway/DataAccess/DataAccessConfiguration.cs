using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Reciplastk.Gateway.DataAccess
{
    public static class DataAccessConfiguration
    {
        public static IServiceCollection AddApplicationDataAccess(this IServiceCollection services, ConfigurationManager config)
        {
            services.AddDbContext<ReciplastkContext>(options => options.UseNpgsql(config.GetConnectionString("ReciplastkContext")));
            return services;
        }
    }
}
