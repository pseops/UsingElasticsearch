using BusinessLogic.Common.Models.Request;
using BusinessLogic.Common.Models.Response;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interfaces
{
    public interface IMainScreenService
    {
        Task<ResponseDropDownValues> GetDropDownValues(RequestDropDownValues request);
    }
}
