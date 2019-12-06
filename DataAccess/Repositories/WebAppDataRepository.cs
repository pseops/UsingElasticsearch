using Dapper;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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

        public async Task<IEnumerable<WebAppData>> GetPartsRecords(int from, int count)
        {
            var sql = $@"GetPartsRecords";

            var watch = new Stopwatch();

            using (var connection = SqlConnection())
            {
                watch.Start();
                var items = await connection.QueryAsync<WebAppData>(
                    sql,
                    new { Skip = from, Take = count },
                    commandType: CommandType.StoredProcedure);

                watch.Stop();
                System.Console.WriteLine(watch);
                return items;
            }
        }
    }
}
