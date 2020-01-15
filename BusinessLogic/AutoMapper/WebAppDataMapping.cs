using AutoMapper;
using Common.Views.MainScreen.Response;
using DataAccess.Entities;

namespace BusinessLogic.AutoMapper
{
    public class WebAppDataMapping : Profile
    {
        public WebAppDataMapping()
        {
            CreateMap<WebAppData, ResponseSearchMainScreenViewItem>();
        }
    }
}
