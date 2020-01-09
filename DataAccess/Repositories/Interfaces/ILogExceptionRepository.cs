using Common.Views.Loggs.Request;
using DataAccess.Common.Views.Response;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces.Base;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface ILogExceptionRepository : IBaseRepository<LogException>
    {
        Task<ResponseGetLoggsView> GetLoggsAsync(RequestGetLoggsView logException);
    }
}
