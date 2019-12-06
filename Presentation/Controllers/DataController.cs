using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.Common.Models;
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

        public DataController(IWebAppDataService webAppDataService, IElasticsearchService elasticsearchService)
        {
            _webAppDataService = webAppDataService;
            _elasticsearchService = elasticsearchService;
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


    }
}
