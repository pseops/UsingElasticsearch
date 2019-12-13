using BusinessLogic.Common.Views.Request;
using BusinessLogic.Common.Views.Response;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interfaces
{
    public interface IMainScreenService
    {
        Task<ResponseGetFiltersMainScreenView> GetFiltersAsync(RequestGetFiltersMainScreenView request);
        Task<ResponseSearchMainScreenView> SearchAsync(RequestSearchMainScreenView request);
    }
}
