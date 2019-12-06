using DataAccess.Entities;
using Nest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interfaces
{
    public interface IWebAppDataService
    {
        Task<IEnumerable<WebAppData>> GetAll();
        //Task<BulkResponse> IndexData();
        //Task<List<WebAppData>> SearchData();
        //Task<List<WebAppData>> TermSearchData();
    }
}
