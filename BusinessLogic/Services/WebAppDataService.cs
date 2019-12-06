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
    }
}
