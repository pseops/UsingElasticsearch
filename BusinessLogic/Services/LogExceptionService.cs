using AutoMapper;
using BusinessLogic.Services.Interfaces;
using Common.Views.Loggs.Request;
using Common.Views.Loggs.Response;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class LogExceptionService : ILogExceptionService
    {
        private readonly IMapper _mapper;
        private readonly ILogExceptionRepository _logExceptionRepository;
        public LogExceptionService(ILogExceptionRepository logExceptionRepository, IMapper mapper)
        {
            _logExceptionRepository = logExceptionRepository;
            _mapper = mapper;
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

        public async Task<ResponseGetLoggsView> GetLoggsAsync(RequestGetLoggsView loggsView)
        {
            var result = await _logExceptionRepository.GetLoggsAsync(loggsView);
            var response = new ResponseGetLoggsView();
            response.Items = _mapper.Map<List<LogException>, List<ResponseGetLoggsViewItem>>(result.Items);
            response.Count = result.Count;
            return response;
        }
    }
}
