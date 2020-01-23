using DataAccess.Entities;
using DataAccess.Repositories.Interfaces.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IUsersPermissionsRepository: IBaseRepository<UsersPermission>
    {
        Task<List<UsersPermission>> GetUserPermissionsAsync(string userId);
    }
}
