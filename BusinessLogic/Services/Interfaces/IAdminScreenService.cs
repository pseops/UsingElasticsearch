using Common.Views.AdminScreen.Request;
using Common.Views.Authetication.Response;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interfaces
{
    public interface IAdminScreenService
    {
        Task<ResponseGetUsersView> GetAllUsers();
        Task CreateUser(RequestCreateUserAdminScreenView model);
        Task UpdateUserAsync(RequestUpdateUserAdminScreenView view);
    }
}
