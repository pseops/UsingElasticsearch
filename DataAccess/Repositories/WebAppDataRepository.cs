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
            string sql = $@"SELECT *  FROM {tableName}";

            using (SqlConnection connection = SqlConnection())
            {
                IEnumerable<WebAppData> items = await connection.QueryAsync<WebAppData>(sql);

                return items;
            }
        }

        public async Task<IEnumerable<WebAppData>> GetPartsRecords(int from, int count)
        {
            string sql = $@"GetPartsRecords";

            var watch = new Stopwatch();

            using (SqlConnection connection = SqlConnection())
            {
                watch.Start();
                IEnumerable<WebAppData> items = await connection.QueryAsync<WebAppData>(
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
