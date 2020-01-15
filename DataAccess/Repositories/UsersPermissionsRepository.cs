using Dapper;
using DataAccess.Entities;
using DataAccess.Repositories.Base;
using DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UsersPermissionsRepository : BaseRepository<UsersPermissions>, IUsersPermissionsRepository
    {
        protected string tableName;

        public UsersPermissionsRepository(IConfiguration configuration) : base(configuration)
        {
            tableName = nameof(UsersPermissions);
        }

        public async Task<List<UsersPermissions>> GetUserPermissionsAsync(string userId)
        {
            string sql = $@"SELECT *  FROM {tableName} 
                        WHERE UserId = @userId";

            using (var connection = SqlConnection())
            {
                IEnumerable<UsersPermissions> query = await connection.QueryAsync<UsersPermissions>(sql, userId);

                return query.ToList();
            }
        }
    }
}
