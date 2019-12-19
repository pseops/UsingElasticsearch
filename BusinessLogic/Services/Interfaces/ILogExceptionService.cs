using Common.Views.Request;
using DataAccess.Common.Views.Response;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interfaces
{
    public interface ILogExceptionService
    {
        Task Create(Exception exception, string url, string userId);
        Task<ResponseGetLoggsView> GetLoggsAsync(RequestGetLoggsView loggsView);
    }
}
