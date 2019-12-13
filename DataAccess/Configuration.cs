using Dapper;
using DataAccess.AppContext;
using DataAccess.Entities;
using DataAccess.Initialization;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace DataAccess
{
    public static class Configuration
    {
        public static void Add(IServiceCollection services, IConfiguration configuration)
        {
            AddDependecies(services);
            AddContext(services, configuration);
            EnsureMigrationOfContext(services);
            SQlMapper();
        }
        public static void Use(IApplicationBuilder app)
        {
        }

        private static void AddContext(IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationContext>(options =>
              options.UseSqlServer(connection), ServiceLifetime.Transient);

            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();
        }
        private static void EnsureMigrationOfContext(IServiceCollection services)
        {
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationContext>();

                if (!context.Database.EnsureCreated())
                {
                    context.Database.Migrate();
                }
            }
        }
        private static void AddDependecies(IServiceCollection services)
        {
            services.AddTransient<IWebAppDataRepository, WebAppDataRepository>();
            services.AddScoped<DbInitializer>();
        }
        private static void SQlMapper()
        {
            SqlMapper.SetTypeMap(typeof(WebAppData), new TitleCaseMap<WebAppData>());
        }

        internal class TitleCaseMap<T> : SqlMapper.ITypeMap where T : new()
        {
            public ConstructorInfo FindExplicitConstructor()
            {
                return null;
            }

            ConstructorInfo SqlMapper.ITypeMap.FindConstructor(string[] names, Type[] types)
            {
                return typeof(T).GetConstructor(Type.EmptyTypes);
            }

            SqlMapper.IMemberMap SqlMapper.ITypeMap.GetConstructorParameter(ConstructorInfo constructor, string columnName)
            {
                return null;
            }

            SqlMapper.IMemberMap SqlMapper.ITypeMap.GetMember(string columnName)
            {
                string reformattedColumnName = string.Empty;

                foreach (string word in columnName.Replace("_", " ").Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    reformattedColumnName += word.First().ToString().ToUpper() + word.Substring(1);
                }

                var prop = typeof(T).GetProperty(reformattedColumnName);

                return prop == null ? null : new PropertyMemberMap(prop);
            }

            class PropertyMemberMap : SqlMapper.IMemberMap
            {
                private readonly PropertyInfo _property;

                public PropertyMemberMap(PropertyInfo property)
                {
                    _property = property;
                }
                string SqlMapper.IMemberMap.ColumnName
                {
                    get { throw new NotImplementedException(); }
                }

                FieldInfo SqlMapper.IMemberMap.Field
                {
                    get { return null; }
                }

                Type SqlMapper.IMemberMap.MemberType
                {
                    get { return _property.PropertyType; }
                }

                ParameterInfo SqlMapper.IMemberMap.Parameter
                {
                    get { return null; }
                }

                PropertyInfo SqlMapper.IMemberMap.Property
                {
                    get { return _property; }
                }
            }
        }
    }
}
