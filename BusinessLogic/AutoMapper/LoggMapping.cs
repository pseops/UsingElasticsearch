using AutoMapper;
using Common.Views.Loggs.Response;
using DataAccess.Entities;

namespace BusinessLogic.AutoMapper
{
    public class LoggMapping : Profile
    {
        public LoggMapping()
        {
            CreateMap<LogException, ResponseGetLoggsViewItem>();
            CreateMap<ResponseGetLoggsViewItem, LogException>();
        }
    }
}
