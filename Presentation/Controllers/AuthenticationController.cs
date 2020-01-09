using System.Threading.Tasks;
using BusinessLogic.Common.Exceptions;
using BusinessLogic.Services.Interfaces;
using Common.Views.Authetication.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Presentation.Common.Response.Views;
using Presentation.Helpers.Interfaces;

namespace Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IJwtHelper _jwtHelper;
        private readonly IConfiguration _configuration;

        public AuthenticationController(
            IAuthenticationService authenticationService,
            IJwtHelper jwtHelper,
            IConfiguration configuration
            )
        {
            _authenticationService = authenticationService;
            _jwtHelper = jwtHelper;
            _configuration = configuration;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] RequestGetAuthenticationView model)
        {
            var responseModel = await _authenticationService.Authenticate(model);

            var tokens = new ResponseGenerateJwtAuthenticationView();

            if (responseModel == null)
            {
                throw new ProjectException(StatusCodes.Status500InternalServerError, "test message: responseModel == null (authentication/login)");
            }

            tokens = _jwtHelper.GenerateJwtToken(responseModel);

            return Ok(tokens);
        }

        [HttpPost("test")]
        public async Task<IActionResult> test()
        {
            throw new ProjectException(StatusCodes.Status500InternalServerError, "test");
            return Ok();
        }
    }
}