using AutoMapper;
using BusinessLogic.Common.Exceptions;
using BusinessLogic.Services.Interfaces;
using Common.Views.AdminScreen.Request;
using Common.Views.Authetication.Response;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Common.Enums.Enums;

namespace BusinessLogic.Services
{
    public class AdminScreenService : IAdminScreenService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUsersPermissionsRepository _usersPermissionsRepository;
        private readonly IMapper _mapper;
        public AdminScreenService(IUsersPermissionsRepository usersPermissionsRepository, IUserRepository userRepository, IMapper mapper)
        {
            _usersPermissionsRepository = usersPermissionsRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ResponseGetUsersView> GetAllUsers()
        {
            List<AppUser> users = await _userRepository.GetAll();

            if (!users.Any())
            {
                throw new ProjectException(StatusCodes.Status500InternalServerError, "users not found");
            }

            ResponseGetUsersView response = new ResponseGetUsersView();
            response.Items = _mapper.Map<List<AppUser>, List<ResponseGetUserItemView>>(users);

            foreach (var item in response.Items)
            {
                var permissions = await _usersPermissionsRepository.GetUserPermissionsAsync(item.Id);

               // permissions = await CheckPermissions(permissions, item.Id);

                item.Permissions = _mapper.Map(permissions, item.Permissions);
            }

            return response;
        }

        public async Task CreateUser(RequestCreateUserAdminScreenView model)
        {
            AppUser user = _mapper.Map<RequestCreateUserAdminScreenView, AppUser>(model);

            if (string.IsNullOrWhiteSpace(user.Email))
            {
                throw new ProjectException(StatusCodes.Status500InternalServerError, "user not found");
            }

            bool isUserCreated = await _userRepository.CreateUserAsync(user);

            if (!isUserCreated)
            {
                throw new ProjectException(StatusCodes.Status500InternalServerError, "user doesn`t created");
            }

            bool isRoleAdded = await _userRepository.AddToRole(user, model.Role.ToString());

            if (!isRoleAdded)
            {
                throw new ProjectException(StatusCodes.Status500InternalServerError, "user role doesn`t added");
            }
            await SetDefaultPermissions(user);
        }

        private async Task SetDefaultPermissions(AppUser user)
        {
            UsersPermission permissions = new UsersPermission();
            permissions.UserId = user.Id;
            permissions.CanEdit = false;
            permissions.CanView = true;

            foreach(var page in Enum.GetValues(typeof(Page)))
            {
                permissions.Page = (Page)page;
                await _usersPermissionsRepository.CreateAsync(permissions);
            }
        }

        //private async Task<List<UsersPermission>> CheckPermissions(List<UsersPermission> permissions, string userId)
        //{
        //    var pages = Enum.GetValues(typeof(Page));

        //    if (permissions.Count == pages.Length)
        //    {
        //        return permissions;
        //    }

        //    var permissionsPages = permissions.Select(x => x.Page);

        //    foreach (var page in pages)
        //    {
        //        if (!permissionsPages.Contains((Page)page)) 
        //        {
        //            UsersPermission newPermissions = new UsersPermission();
        //            newPermissions.UserId = userId;
        //            newPermissions.CanEdit = false;
        //            newPermissions.CanView = true;
        //            newPermissions.Page = (Page)page;
        //            await _usersPermissionsRepository.CreateAsync(newPermissions);

        //            permissions.Add(newPermissions);
        //        }
        //    }
        //    return permissions;
        //}

        public async Task UpdateUserAsync(RequestUpdateUserAdminScreenView view)
        {
            if(view == null)
            {
                throw new ProjectException(StatusCodes.Status500InternalServerError, "view is empty");
            }

            AppUser user = await _userRepository.FindUserByIdAsync(view.Id);

            if(user == null)
            {
                throw new ProjectException(StatusCodes.Status500InternalServerError, "user not found");
            }

            user = _mapper.Map(view, user);
            await _userRepository.UpdateUserAsync(user);
            
            var permissions = await _usersPermissionsRepository.GetUserPermissionsAsync(user.Id);

            permissions = _mapper.Map(view.Permissions, permissions);

            foreach(var permisssion in permissions)
            {
                await _usersPermissionsRepository.UpdateAsync(permisssion);
            }
        }

    }
}
