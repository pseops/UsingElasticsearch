using Dapper;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
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

        public async Task<List<WebAppData>> GetAllAsync()
        {
            var sql = $@"SELECT *  FROM {tableName}";

            using (var connection = SqlConnection())
            {
                var items = await connection.QueryAsync<WebAppData>(sql);

                return items.ToList();
            }
        }
    }
}
