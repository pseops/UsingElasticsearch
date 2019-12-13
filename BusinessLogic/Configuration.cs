using BusinessLogic.Options;
using BusinessLogic.Services;
using BusinessLogic.Services.Interfaces;
using DataAccess.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;

namespace BusinessLogic
{
    public class Configuration
    {
        public static void Add(IServiceCollection services, IConfiguration configuration)
        {
            DataAccess.Configuration.Add(services, configuration);
            AddDependecies(services);
            AddElasticOptions(services, configuration);

        }
        public static void Use(IApplicationBuilder app)
        {
            DataAccess.Configuration.Use(app);
        }

        private static void AddDependecies(IServiceCollection services)
        {
            services.AddTransient<IElasticsearchService, ElasticsearchService>();
            services.AddTransient<IMainScreenService, MainScreenService>();

        }

        private static void AddElasticOptions(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ElasticOptions>(configuration.GetSection(nameof(ElasticOptions)));

            IConfiguration elasticOptions = configuration.GetSection(nameof(ElasticOptions));

            var uri = elasticOptions.GetSection(nameof(ElasticOptions.Uri))?.Value;

            var index = elasticOptions.GetSection(nameof(ElasticOptions.Index))?.Value;

            var settings = new ConnectionSettings(new Uri(uri))
                .DefaultMappingFor<WebAppData>(x => x.IndexName(index));

            var client = new ElasticClient(settings);

            services.AddSingleton<IElasticClient>(client);
        }
    }
}
