using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cotecna.Inspections.Application
{
    public static class Startup
    {
        public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            Data.Startup.ConfigureServices(configuration, services);

        }

        public static void Configure(IServiceScope serviceScope)
        {
            Data.Startup.Configure(serviceScope);
        }
    }
}
