using Common.Views.Loggs.Request;
using Common.Views.Loggs.Response;
using Dapper;
using DataAccess.Common.Models;
using DataAccess.Entities;
using DataAccess.Repositories.Base;
using DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class LogExceptionRepository : BaseRepository<LogException>, ILogExceptionRepository
    {
        protected string tableName;

        public LogExceptionRepository(IConfiguration configuration): base(configuration)
        {
            tableName = typeof(LogException).GetCustomAttribute<TableAttribute>().Name;
        }

        public async Task<LoggExceptionModel> GetLoggsAsync(RequestGetLoggsView loggsView)
        {
            string sql = $@"SELECT *  FROM {tableName}
                        ORDER BY Id ASC
                        OFFSET(@PageNumber - 1) * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY; 
                        SELECT COUNT(*)  FROM {tableName}";


            using (var connection = SqlConnection())
            {
                var query = await connection.QueryMultipleAsync(sql, loggsView);
                IEnumerable<LogException> items = query.Read<LogException>();
                int count = query.Read<int>().FirstOrDefault();
                var response = new LoggExceptionModel();
                response.Items = items.ToList();
                response.Count = count;
                return response;
            }
        }
    }
}
