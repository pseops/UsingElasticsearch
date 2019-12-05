using DataAccess.Entities;
using Nest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IWebAppDataRepository
    {
        Task<IEnumerable<WebAppData>> GetAllAsync();
        Task<BulkResponse> ElasticIndexData(IEnumerable<WebAppData> data);
        Task<List<WebAppData>> ElasticSearch();
        Task<List<WebAppData>> ElasticSearchTerm();
    }
}
