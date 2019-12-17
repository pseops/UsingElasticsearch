using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Common.Extensions;
using Presentation.Helpers.Interfaces;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace Presentation
{
    public static class Configuration
    {
        public static void Add(IServiceCollection services, IConfiguration configuration)
        {
            BusinessLogic.Configuration.Add(services, configuration);
            AddDependecies(services);
            services.AddJwtAuthentication(configuration);
            AddSwagger(services);
            AddCors(services, configuration);
            AddIdentityOptions(services);
        }

        private static void AddDependecies(IServiceCollection services)
        {
            services.AddTransient<IJwtHelper, JwtHelper>();
        }

        private static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Elastic API", Version = "V1" });
            });
        }

        private static void AddCors(IServiceCollection services, IConfiguration configuration)
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

        private static void AddIdentityOptions(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 2;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
            });
        }
    }
}
