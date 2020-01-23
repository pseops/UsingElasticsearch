using BusinessLogic.Services.Interfaces;
using Common.Views.AdminScreen.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    //[Authorize]
    //[Route("api/[controller]")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class AdminScreenController : ControllerBase
    {
        private readonly IAdminScreenService _adminScreenService;

        public AdminScreenController(IAdminScreenService adminScreenService)
        {
            _adminScreenService = adminScreenService;
        }

        //[HttpGet("getallusers")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var res = await _adminScreenService.GetAllUsers();

            return Ok(res);
        }

        //[HttpPost("createuser")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] RequestCreateUserAdminScreenView model)
        {
            await _adminScreenService.CreateUser(model);

            return Ok();
        }

        //[HttpPost("updateuser")]
        [HttpPost]
        public async Task<IActionResult> UpdateUser([FromBody] RequestUpdateUserAdminScreenView model)
        {
            await _adminScreenService.UpdateUserAsync(model);

            return Ok();
        }
    }
}