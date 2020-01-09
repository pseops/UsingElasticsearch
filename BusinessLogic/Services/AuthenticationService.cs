using BusinessLogic.Common.Exceptions;
using BusinessLogic.Services.Interfaces;
using Common.Views.Authetication.Request;
using Common.Views.Authetication.Response;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;       

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            
        }

        public async Task<ResponseGetUserItemView> Authenticate(RequestGetAuthenticationView model)
        {
            if (model == null)
            {
                throw new ProjectException(StatusCodes.Status500InternalServerError, "test message: model == null");
            }

            var user = await _userRepository.FindUserByEmailAsync(model.Email);

            if (user == null)
            {
                throw new ProjectException(StatusCodes.Status500InternalServerError, "test message: user == null");
            }

            var passwordCheck = await _userRepository.PasswordCheckAsync(user.UserName, model.Password);

            if (!passwordCheck)
            {
                throw new ProjectException(StatusCodes.Status500InternalServerError, "test message: wrong password");
            }

            var userView = new ResponseGetUserItemView();
            userView.Email = user.Email;
            userView.Id = user.Id;
            userView.UserName = user.UserName;
            userView.Role = user.Role;

            return userView;
        }

        public async Task<bool> CreateUserAsync(ResponseGetUserItemView user)
        {
            var appUser = new AppUser();
            appUser.Email = user.Email;
            appUser.UserName = user.UserName;
            appUser.FirstName = user.FirstName;
            appUser.LastName = user.LastName;
            appUser.Password = user.Password;
            appUser.Role = user.Role;

            var result = await _userRepository.CreateUserAsync(appUser);

            return result;
        }

    }
}
