using BusinessLogic.Common.Models;
using Nest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interfaces
{
    public interface IElasticsearchService
    {
        Task<SearchResponseView> TermSearchAsync(TermSearchFilter filter);
        Task<List<BulkResponseItemBase>> IndexData();
        Task<SearchResponseView> RangeSearchAsync(RangeSearchFilter filter);
        
    }
}
