using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Presentation
{
    public class Configuration
    {
        public static void Add(IServiceCollection services, IConfiguration configuration)
        {
            BusinessLogic.Configuration.Add(services, configuration);
            AddSwagger(services);
            AddCors(services, configuration);
        }

        public static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Elastic API", Version = "V1" });
            });
        }

        public static void AddCors(IServiceCollection services, IConfiguration configuration)
        {
            IConfigurationSection corsOptions = configuration.GetSection("Cors");

            var origins = corsOptions["Origins"];

            services.AddCors(options =>
            {
                options.AddPolicy("AllPolicy", builder => builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .WithExposedHeaders());

                options.AddPolicy("OriginPolicy", builder => builder.WithOrigins(origins)
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .WithExposedHeaders());
            });
        }

    }
}
