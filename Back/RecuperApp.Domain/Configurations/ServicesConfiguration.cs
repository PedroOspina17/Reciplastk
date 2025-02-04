using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Repositories;
using RecuperApp.Domain.Services;
using RecuperApp.Domain.Services.Interfaces;

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
            services.AddScoped(typeof(IApplicationService<>), typeof(ApplicationService<>));
            services.AddScoped(typeof(IApplicationService<,>), typeof(ApplicationService<,>));
            services.AddScoped<ShipmentService>();
            services.AddScoped<CustomerService>();
            services.AddScoped<WeightControlTypeService>();
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IShipmentTypeService, ShipmentTypeService>();
            services.AddScoped<IWeightControlService,WeightControlService>();
            services.AddScoped<IPaymentService, PaymentService>();
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
