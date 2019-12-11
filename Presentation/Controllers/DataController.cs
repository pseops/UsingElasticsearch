using System.Threading.Tasks;
using BusinessLogic.Common.Views;
using BusinessLogic.Common.Views.Request;
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

        [HttpPost("getdropdownvalues")]
        public async Task<IActionResult> GetDropDownValues([FromBody]RequestFiltersMainScreenView request)
        {            
            var result = await _mainScreenService.GetDropDownValues(request);
            return Ok(result);
        }
    }
}
