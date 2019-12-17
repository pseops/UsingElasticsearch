using BusinessLogic.Common.Views.Request;
using BusinessLogic.Common.Views.Response.User;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<ResponseGetUserItemView> Authenticate(RequestGetAuthenticationView model);
    }
}
