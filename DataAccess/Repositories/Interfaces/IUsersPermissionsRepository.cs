using DataAccess.Entities;
using DataAccess.Repositories.Interfaces.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IUsersPermissionsRepository: IBaseRepository<UsersPermissions>
    {
        Task<List<UsersPermissions>> GetUserPermissionsAsync(string userId);
    }
}
