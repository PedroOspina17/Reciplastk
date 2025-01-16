using System.Reflection;

namespace Reciplastk.Gateway.Services
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddApplicationAutoMapper(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IMySimpleService, MySimpleService>();
            services.AddScoped<ShipmentService>();
            services.AddScoped<ShipmentTypeService>();
            services.AddScoped<CustomerService>();
            services.AddScoped<WeightControlTypeService>();
            services.AddScoped<WeightControlService>();
            services.AddScoped<ProductsService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IRoleService, RoleService>();
            return services;
        }
    }
}
