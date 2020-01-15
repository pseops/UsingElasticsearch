using Common.Views.Authetication.Request;
using Common.Views.Authetication.Response;
using DataAccess.Entities;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<ResponseGetUserItemView> Authenticate(RequestGetAuthenticationView model);
        Task<AppUser> GetPermissionsForUserAsync(AppUser user);
        Task<AppUser> GetUserWithPermissionsByIdAsync(string userId);
    }
}
