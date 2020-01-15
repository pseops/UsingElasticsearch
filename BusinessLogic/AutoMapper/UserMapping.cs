using AutoMapper;
using Common.Views.Authetication.Response;
using DataAccess.Entities;

namespace BusinessLogic.AutoMapper
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<AppUser, ResponseGetUserItemView>();
            CreateMap<ResponseGetUserItemView, AppUser>();
        }
    }
}
