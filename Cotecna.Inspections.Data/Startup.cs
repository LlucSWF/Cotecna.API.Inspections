using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Cotecna.Inspections.Data.Repositories.Investel.CustomerSite.Data.Repositories;
using Cotecna.Inspections.Data.Repositories;

namespace Cotecna.Inspections.Data
{

    public static class Startup
    {
        public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {


            var connString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<InspectionsContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("InspectionsContext"));
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IInspectorRepository, InspectorRepository>();

            services.AddScoped<IInspectionRepository, InspectionRepository>();


            //var aspNetConnString = configuration.GetConnectionString("AspNetConnection");
            //services.AddDbContext<InspectionsContext>(options =>
            //{
            //    options.UseSqlServer(aspNetConnString, opt =>
            //    {
            //        opt.UseRowNumberForPaging();
            //    });
            //});
        }

        public static void Configure(IServiceScope serviceScope)
        {
        }
    }
}