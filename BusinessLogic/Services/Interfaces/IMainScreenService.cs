using BusinessLogic.Common.Views;
using BusinessLogic.Common.Views.Request;
using BusinessLogic.Common.Views.Response;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interfaces
{
    public interface IMainScreenService
    {
        Task<ResponseFiltersMainScreenView> GetDropDownValues(RequestFiltersMainScreenView request);
        Task<ResponseSearchMainScreenView> SearchAsync(RequestSearchMainScreenView request);
    }
}
