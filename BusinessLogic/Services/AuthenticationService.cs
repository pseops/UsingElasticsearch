using BusinessLogic.Common.Exceptions;
using BusinessLogic.Common.Views.Request;
using BusinessLogic.Common.Views.Response.User;
using BusinessLogic.Services.Interfaces;
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

            if (!passwordCheck.Succeeded)
            {
                throw new ProjectException(StatusCodes.Status500InternalServerError, "test message");
            }

            var userView = new ResponseGetUserItemView();
            userView.Email = user.Email;
            userView.Id = user.Id;
            userView.UserName = user.UserName;
            return userView;

            throw new ProjectException(StatusCodes.Status500InternalServerError, "test message");
        }


    }
}
