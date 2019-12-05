using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IWebAppDataService _webAppDataService;

        public DataController(IWebAppDataService webAppDataService)
        {
            _webAppDataService = webAppDataService;
        }

        [HttpGet("getdata")]
        public async Task<IActionResult> GetData()
        {
            var result = await _webAppDataService.IndexData();
            return Ok(result.Errors);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _webAppDataService.SearchData();
            return Ok(result);
        }

        [HttpGet("termsearch")]
        public async Task<IActionResult> TermSearch()
        {
            var result = await _webAppDataService.TermSearchData();
            return Ok(result);
        }

    }
}
