using BusinessLogic.Services;
using BusinessLogic.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic
{
    public class Configuration
    {
        public static void Add(IServiceCollection services, string connectionString)
        {
            AddDependecies(services);
            DataAccess.Configuration.Add(services, connectionString);
        }

        public static void AddDependecies(IServiceCollection services)
        {
            services.AddTransient<IWebAppDataService, WebAppDataService>();
        }        
    }
}
