namespace Reciplastk.Gateway.Services
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IMySimpleService, MySimpleService>();
            services.AddScoped<SecurityService>();
            services.AddScoped<ShipmentService>();
            services.AddScoped<ShipmentTypeService>();
            services.AddScoped<CustomerService>();
            services.AddScoped<WeightControlTypeService>();
            services.AddScoped<WeightControlService>();
            services.AddScoped<ProductsService>();
            services.AddScoped<CustomerTypeService>();
            services.AddScoped<ProductPricesService>();
            return services;
        }
    }
}
