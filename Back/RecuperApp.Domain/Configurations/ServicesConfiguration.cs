using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecuperApp.Domain.Services;

namespace RecuperApp.Domain.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddApplicationAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ShipmentService>();
            services.AddScoped<ShipmentTypeService>();
            services.AddScoped<CustomerService>();
            services.AddScoped<WeightControlTypeService>();
            services.AddScoped<WeightControlService>();
            services.AddScoped<ProductsService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<CustomerTypeService>();
            services.AddScoped<ChartsService>();
            services.AddScoped<KpiService>();
            services.AddScoped<ProductPricesService>();
            services.AddScoped<PayrollConfigService>();
            return services;
        }
    }
}
