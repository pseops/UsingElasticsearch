using AutoMapper;
using Common.Models;
using Common.Views.AdminScreen.Request;
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
            CreateMap<UsersPermission, UsersPermissionsModel>();
            CreateMap<UsersPermissionsModel, UsersPermission> ();
            CreateMap<RequestCreateUserAdminScreenView, AppUser>();
            CreateMap<AppUser, RequestCreateUserAdminScreenView>();
            CreateMap<RequestUpdateUserAdminScreenView, AppUser>();
            CreateMap<AppUser, RequestUpdateUserAdminScreenView>();

        }
    }
}
