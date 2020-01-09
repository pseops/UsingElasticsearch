using Common.Views.Loggs.Request;
using Dapper;
using DataAccess.Common.Views.Response;
using DataAccess.Entities;
using DataAccess.Repositories.Base;
using DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
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

        public async Task<ResponseGetLoggsView> GetLoggsAsync(RequestGetLoggsView loggsView)
        {
            var sql = $@"SELECT *  FROM {tableName}
                        ORDER BY Id ASC
                        OFFSET(@PageNumber - 1) * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY; 
                        SELECT COUNT(*)  FROM {tableName}";


            using (var connection = SqlConnection())
            {
                var query = await connection.QueryMultipleAsync(sql, loggsView);
                var items = query.Read<LogException>();
                var count = query.Read<int>().FirstOrDefault();
                var response = new ResponseGetLoggsView();
                response.Items = items.ToList();
                response.Count = count;
                return response;
            }
        }
    }
}
