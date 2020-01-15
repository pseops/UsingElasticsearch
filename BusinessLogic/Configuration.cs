using AutoMapper;
using BusinessLogic.AutoMapper;
using BusinessLogic.Services;
using BusinessLogic.Services.Interfaces;
using Common.Options;
using DataAccess.Entities;
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
            ConfigureAutomapper(services);
        }

        private static void AddDependecies(IServiceCollection services)
        {
            services.AddTransient<IElasticsearchService, ElasticsearchService>();
            services.AddTransient<IMainScreenService, MainScreenService>();
            services.AddTransient<ILogExceptionService, LogExceptionService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAdminScreenService, AdminScreenService>();
        }

        private static void ConfigureAutomapper(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new WebAppDataMapping());
                mc.AddProfile(new UserMapping());
                mc.AddProfile(new LoggMapping());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
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
