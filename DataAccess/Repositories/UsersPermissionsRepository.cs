using Dapper;
using DataAccess.Entities;
using DataAccess.Repositories.Base;
using DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Common.Enums.Enums;

namespace DataAccess.Repositories
{
    public class UsersPermissionsRepository : BaseRepository<UsersPermission>, IUsersPermissionsRepository
    {
        protected string tableName;

        public UsersPermissionsRepository(IConfiguration configuration) : base(configuration)
        {
            tableName = nameof(UsersPermission)+"s";
        }

        public async Task<List<UsersPermission>> GetUserPermissionsAsync(string userId)
        {
            string sql = $@"SELECT *  FROM {tableName} 
                        WHERE UserId = @userId";

            using (var connection = SqlConnection())
            {
                IEnumerable<UsersPermission> query = await connection.QueryAsync<UsersPermission>(sql,  new { userId });

                var permissions = query.ToList();

                permissions = await CheckPermissions(permissions, userId);

                return permissions;
            }
        }

        private async Task<List<UsersPermission>> CheckPermissions(List<UsersPermission> permissions, string userId)
        {
            var pages = Enum.GetValues(typeof(Page));

            if (permissions.Count == pages.Length)
            {
                return permissions;
            }

            var permissionsPages = permissions.Select(x => x.Page);

            foreach (var page in pages)
            {
                if (!permissionsPages.Contains((Page)page))
                {
                    UsersPermission newPermissions = new UsersPermission();
                    newPermissions.UserId = userId;
                    newPermissions.CanEdit = false;
                    newPermissions.CanView = true;
                    newPermissions.Page = (Page)page;
                    await CreateAsync(newPermissions);

                    permissions.Add(newPermissions);
                }
            }
            return permissions;
        }
    }
}
