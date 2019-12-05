using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Presentation
{
    public class Configuration
    {
        public static void Add(IServiceCollection services, string connectionString)
        {
            BusinessLogic.Configuration.Add(services, connectionString);
            AddSwagger(services);
        }

        public static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Elastic API", Version = "V1" });
            });
        }

    }
}
