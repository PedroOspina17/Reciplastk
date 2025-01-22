using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace RecuperApp.Common.Configurations
{
    public static class ConfigureStaticLogger
    {
        public static void ConfigureApplicationStaticLogger(this IHost app)
        {

            using var scope = app.Services.CreateScope();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<StaticLogger>>();
            StaticLogger.logger = logger;
        }
    }
}
