using BusinessLogic.Services;
using BusinessLogic.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class Configuration
    {
        public static void Add(IServiceCollection services, string connectionString)
        {
            AddDependecies(services, connectionString);
        }

        public static void AddDependecies(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IWebAppDataService, WebAppDataService>();
        }
    }
}
