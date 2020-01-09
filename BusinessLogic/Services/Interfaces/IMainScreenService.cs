using Common.Views.MainScreen.Request;
using Common.Views.MainScreen.Response;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interfaces
{
    public interface IMainScreenService
    {
        Task<ResponseGetFiltersMainScreenView> GetFiltersAsync(RequestGetFiltersMainScreenView request);
        Task<ResponseSearchMainScreenView> SearchAsync(RequestSearchMainScreenView request);
    }
}
