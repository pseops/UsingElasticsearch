using System.Threading.Tasks;
using BusinessLogic.Common.Models;
using BusinessLogic.Common.Models.Request;
using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IWebAppDataService _webAppDataService;
        private readonly IElasticsearchService _elasticsearchService;
        private readonly IMainScreenService _mainScreenService;

        public DataController(IWebAppDataService webAppDataService, IElasticsearchService elasticsearchService, IMainScreenService mainScreenService)
        {
            _webAppDataService = webAppDataService;
            _elasticsearchService = elasticsearchService;
            _mainScreenService = mainScreenService;
        }

        [HttpGet("getdata")]
        public async Task<IActionResult> GetData()
        {
            var result = await _elasticsearchService.IndexData();
            return Ok(result);
        }

        [HttpPost("rangesearch")]
        public async Task<IActionResult> RangeSearch([FromBody] RangeSearchFilter filter)
        {
            var result = await _elasticsearchService.RangeSearchAsync(filter);
            return Ok(result);
        }

        [HttpPost("termsearch")]
        public async Task<IActionResult> TermSearch([FromBody]TermSearchFilter filter)
        {
            var result = await _elasticsearchService.TermSearchAsync(filter);
            return Ok(result);
        }

        [HttpPost("getdropdownvalues")]
        public async Task<IActionResult> GetDropDownValues([FromBody]RequestDropDownValues request)
        {
            var result = await _mainScreenService.GetDropDownValues(request);
            return Ok(result);
        }
    }
}
