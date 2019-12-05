﻿using Dapper;
using DataAccess.Entities;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace DataAccess
{
    public class Configuration
    {
        public static void Add(IServiceCollection services, string connectionString)
        {
            AddDependecies(services);
            SQlMapper();
        }

        public static void AddDependecies(IServiceCollection services)
        {
            services.AddTransient<IWebAppDataRepository, WebAppDataRepository>();
        }

        public static void SQlMapper()
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
