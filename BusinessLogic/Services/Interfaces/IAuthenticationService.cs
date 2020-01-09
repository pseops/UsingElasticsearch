using Common.Views.Authetication.Request;
using Common.Views.Authetication.Response;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<ResponseGetUserItemView> Authenticate(RequestGetAuthenticationView model);
    }
}
