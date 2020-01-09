using AutoMapper;
using Common.Views.MainScreen.Response;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
