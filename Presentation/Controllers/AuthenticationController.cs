using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Common.Exceptions;
using BusinessLogic.Common.Views.Request;
using BusinessLogic.Services.Interfaces;
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
        //private readonly JwtOptionsModel _jwtOptions;

        public AuthenticationController(
            IAuthenticationService authenticationService,
            IJwtHelper jwtHelper,
            IConfiguration configuration
            //IOptions<JwtOptionsModel> jwtOptions
            )
        {
            _authenticationService = authenticationService;
            _jwtHelper = jwtHelper;
            _configuration = configuration;
            //_jwtOptions = jwtOptions.Value;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] RequestGetAuthenticationView model)
        {
            var responseModel = await _authenticationService.Authenticate(model);

            var tokens = new ResponseGenerateJwtAuthenticationView();

            if (responseModel == null)
            {
                throw new ProjectException(StatusCodes.Status500InternalServerError, "test message: responseModel == null");
            }

            tokens = _jwtHelper.GenerateJwtToken(responseModel);

            //throw new ProjectException(StatusCodes.Status500InternalServerError, "test");
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