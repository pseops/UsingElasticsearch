using System.Threading.Tasks;
using BusinessLogic.Common.Views.Request;
using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IElasticsearchService _elasticsearchService;
        private readonly IMainScreenService _mainScreenService;

        public DataController(IElasticsearchService elasticsearchService, IMainScreenService mainScreenService)
        {
            _elasticsearchService = elasticsearchService;
            _mainScreenService = mainScreenService;
        }

        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            var result = await _elasticsearchService.IndexData();
            return Ok(result);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody]RequestSearchMainScreenView filter)
        {
            var result = await _mainScreenService.SearchAsync(filter);
            return Ok(result);
        }

        [HttpPost("getfilters")]
        public async Task<IActionResult> GetFilters([FromBody]RequestGetFiltersMainScreenView request)
        {            
            var result = await _mainScreenService.GetFiltersAsync(request);
            return Ok(result);
        }
    }
}
