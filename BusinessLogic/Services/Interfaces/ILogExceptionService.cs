using Common.Views.Loggs.Request;
using Common.Views.Loggs.Response;
using System;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interfaces
{
    public interface ILogExceptionService
    {
        Task Create(Exception exception, string url, string userId);
        Task<ResponseGetLoggsView> GetLoggsAsync(RequestGetLoggsView loggsView);
    }
}
