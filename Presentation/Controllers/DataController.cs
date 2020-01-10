using System.Threading.Tasks;
using BusinessLogic.Services.Interfaces;
using Common.Views.Loggs.Request;
using Common.Views.MainScreen.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DataController : ControllerBase
    {
        private readonly IElasticsearchService _elasticsearchService;
        private readonly IMainScreenService _mainScreenService;
        private readonly ILogExceptionService _logExceptionService;


        public DataController(IElasticsearchService elasticsearchService, IMainScreenService mainScreenService, ILogExceptionService logExceptionService)
        {
            _elasticsearchService = elasticsearchService;
            _mainScreenService = mainScreenService;
            _logExceptionService = logExceptionService;
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

        [HttpPost("getloggs")]
        public async Task<IActionResult> GetLoggs([FromBody]RequestGetLoggsView request)
        {
            var result = await _logExceptionService.GetLoggsAsync(request);
            return Ok(result);
        }
    }
}
