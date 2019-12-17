using BusinessLogic.Services.Interfaces;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class LogExceptionService : ILogExceptionService
    {
        private readonly ILogExceptionRepository _logExceptionRepository;
        public LogExceptionService(ILogExceptionRepository logExceptionRepository)
        {
            _logExceptionRepository = logExceptionRepository;
        }

        public async Task Create(Exception exception, string url, string userId)
        {
            var exceptionToInsert = new LogException();  
            exceptionToInsert.Message = exception.InnerException != null ? exception.InnerException.Message : exception.Message;
            exceptionToInsert.Request = url;
            exceptionToInsert.Source = exception.Source;
            exceptionToInsert.StackTrace = exception.InnerException != null ? exception.InnerException.StackTrace : exception.StackTrace;
            exceptionToInsert.UserId = userId;

            await _logExceptionRepository.CreateAsync(exceptionToInsert);
        }
    }
}
