using BusinessLogic.Services.Interfaces;
using DataAccess.Repositories.Interfaces;

namespace BusinessLogic.Services
{
    public class AdminScreenService : IAdminScreenService
    {
        private readonly IUsersPermissionsRepository _usersPermissionsRepository;
        public AdminScreenService(IUsersPermissionsRepository usersPermissionsRepository)
        {
            _usersPermissionsRepository = usersPermissionsRepository;
        }
    }
}
