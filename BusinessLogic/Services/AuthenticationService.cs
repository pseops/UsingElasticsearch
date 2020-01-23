using AutoMapper;
using BusinessLogic.Common.Exceptions;
using BusinessLogic.Services.Interfaces;
using Common.Views.Authetication.Request;
using Common.Views.Authetication.Response;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUsersPermissionsRepository _usersPermissionsRepository;
        private readonly IMapper _mapper;

        public AuthenticationService(IUserRepository userRepository, IMapper mapper, IUsersPermissionsRepository usersPermissionsRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _usersPermissionsRepository = usersPermissionsRepository;
        }

        public async Task<ResponseGetUserItemView> Authenticate(RequestGetAuthenticationView model)
        {
            if (model == null)
            {
                throw new ProjectException(StatusCodes.Status500InternalServerError, "test message: model == null");
            }

            AppUser user = await _userRepository.FindUserByEmailAsync(model.Email);            
            if (user == null)
            {
                throw new ProjectException(StatusCodes.Status500InternalServerError, "test message: user == null");
            }

            bool passwordCheck = await _userRepository.PasswordCheckAsync(user.UserName, model.Password);

            if (!passwordCheck)
            {
                throw new ProjectException(StatusCodes.Status500InternalServerError, "test message: wrong password");
            }

            await _userRepository.SignInUserAsync(user);

            user = await GetPermissionsForUserAsync(user);
            ResponseGetUserItemView userView = _mapper.Map<AppUser, ResponseGetUserItemView>(user);

            return userView;
        }

        public async Task<AppUser> GetPermissionsForUserAsync(AppUser user)
        {
            List<UsersPermission> permissions = await _usersPermissionsRepository.GetUserPermissionsAsync(user.Id);

            user.Permissions = permissions;

            return user;
        }

        public async Task<AppUser> GetUserWithPermissionsByIdAsync(string userId)
        {
            AppUser user = await _userRepository.FindUserByIdAsync(userId);

            ResponseGetUserItemView userView = _mapper.Map<AppUser, ResponseGetUserItemView>(user);

            List<UsersPermission> permissions = await _usersPermissionsRepository.GetUserPermissionsAsync(user.Id);

            user.Permissions = permissions;

            return user;
        }


        public async Task<bool> CreateUserAsync(ResponseGetUserItemView user)
        {

            AppUser appUser = _mapper.Map<ResponseGetUserItemView, AppUser>(user);

            bool result = await _userRepository.CreateUserAsync(appUser);

            return result;
        }

    }
}
