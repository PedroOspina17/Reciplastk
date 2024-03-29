﻿namespace Reciplastk.Gateway.Services
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IMySimpleService, MySimpleService>();
            services.AddScoped<SecurityService>();
            return services;
        }
    }
}
