using System.Threading.Tasks;
using BusinessLogic.Common.Exceptions;
using BusinessLogic.Services.Interfaces;
using Common.Views.Authetication.Request;
using Common.Views.Authetication.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Presentation.Helpers.Interfaces;

namespace Presentation.Controllers
{

    //[AllowAnonymous]
    [Route("[controller]/[action]")]
    //[Route("api/[controller]")]
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


        //[HttpPost("Login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] RequestGetAuthenticationView model)
        {
            ResponseGetUserItemView responseModel = await _authenticationService.Authenticate(model);

            var tokens = new ResponseGenerateJwtAuthenticationView();

            if (responseModel == null)
            {
                throw new ProjectException(StatusCodes.Status500InternalServerError, "test message: responseModel == null (authentication/login)");
            }

            tokens = _jwtHelper.GenerateJwtToken(responseModel);

            return Ok(tokens);
        }

        //[HttpPost("refreshtoken")]
        [HttpPost]
        public async Task<IActionResult> RefreshToken([FromBody]ResponseGenerateJwtAuthenticationView credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ResponseGenerateJwtAuthenticationView jwt = _jwtHelper.RefreshToken(credentials);
            return Ok(jwt);
        }

        //[HttpPost("test")]
        [HttpPost]
        public async Task<IActionResult> test()
        {
            throw new ProjectException(StatusCodes.Status500InternalServerError, "test");
            return Ok();
        }
    }
}