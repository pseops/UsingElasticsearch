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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _elasticsearchService.ElasticSearch();
            return Ok(result);
        }

        [HttpGet("termsearch")]
        public async Task<IActionResult> TermSearch()
        {
            var result = await _elasticsearchService.ElasticSearchTerm();
            return Ok(result);
        }

        [HttpGet("test")]
        public async Task<IActionResult> Test()
        {
            var result = await _elasticsearchService.GetPartsRecords();
            return Ok(result);
        }

    }
}
