using DataAccess.Entities;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interfaces
{
    public interface IElasticsearchService
    {
        Task<List<WebAppData>> ElasticSearch();
        Task<List<WebAppData>> ElasticSearchTerm();
        Task<List<BulkResponseItemBase>> IndexData();
        Task<IEnumerable<WebAppData>> GetPartsRecords();
    }
}
