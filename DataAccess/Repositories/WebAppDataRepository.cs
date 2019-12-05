using Dapper;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Elasticsearch.Net;
using Microsoft.Extensions.Configuration;
using Nest;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class WebAppDataRepository : IWebAppDataRepository
    {
        private readonly IConfiguration _configuration;
        protected string tableName;

        public WebAppDataRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            tableName = typeof(WebAppData).GetCustomAttribute<TableAttribute>().Name;
        }

        protected SqlConnection SqlConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<IEnumerable<WebAppData>> GetAllAsync()
        {
            var sql = $@"SELECT *  FROM {tableName}";

            using (var connection = SqlConnection())
            {
                var items = await connection.QueryAsync<WebAppData>(sql);

                return items;
            }
        }

        public async Task<BulkResponse> ElasticIndexData(IEnumerable<WebAppData> data)
        { 
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
                .DefaultIndex(nameof(WebAppData).ToLower());
            
            var client = new ElasticClient(settings);

            
            var response = await client.BulkAsync(x => x.IndexMany(data));   

            return response;
        }

        public async Task<List<WebAppData>> ElasticSearch()
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
                .DefaultIndex(nameof(WebAppData).ToLower());

            var client = new ElasticClient(settings);

            var searchResponse = await client.SearchAsync<WebAppData>(s => s
                .From(0)
                .Size(10)
                .Query(q => q
                    .Range(x=>x
                        .Field(c=>c.RecId)
                            .GreaterThanOrEquals(1)
                            .LessThanOrEquals(3)
                    )                     
                )
            );

            var webAppDatas = searchResponse.Documents.ToList();

            return webAppDatas;
        }

        public async Task<List<WebAppData>> ElasticSearchTerm()
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
                .DefaultIndex(nameof(WebAppData).ToLower());

            var client = new ElasticClient(settings);

            var searchResponse = await client.SearchAsync<WebAppData>(s => s
                .From(0)
                .Size(10)
                .Query(q => q
                    .Term(t=>t.RecId, 1)|| q
                    .Term(r=>r.RecId , 3)                    
                )
            );

            var webAppDatas = searchResponse.Documents.ToList();

            return webAppDatas;
        }

    }
}
