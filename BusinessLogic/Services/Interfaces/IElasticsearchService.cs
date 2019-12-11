using BusinessLogic.Common.Views;
using Nest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interfaces
{
    public interface IElasticsearchService
    {
        Task<List<BulkResponseItemBase>> IndexData();
        
    }
}
