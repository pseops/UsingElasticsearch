using BusinessLogic.Services.Interfaces;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Nest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class WebAppDataService : IWebAppDataService
    {
        private readonly IWebAppDataRepository _dataRepository;

        public WebAppDataService(IWebAppDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<IEnumerable<WebAppData>> GetAll()
        {
            return await _dataRepository.GetAllAsync();
        }

        public async Task<BulkResponse> IndexData()
        {
            var data = await GetAll();
            var result = await _dataRepository.ElasticIndexData(data);
            return result;
        }

        public async Task<List<WebAppData>> SearchData()
        {
            var response = await _dataRepository.ElasticSearch();
            return response;
        }

        public async Task<List<WebAppData>> TermSearchData()
        {
            var response = await _dataRepository.ElasticSearchTerm();
            return response;
        }
    }
}
