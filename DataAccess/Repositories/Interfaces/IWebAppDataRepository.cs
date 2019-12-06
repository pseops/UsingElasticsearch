using DataAccess.Entities;
using Nest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IWebAppDataRepository
    {
        Task<IEnumerable<WebAppData>> GetAllAsync();
        Task<IEnumerable<WebAppData>> GetPartsRecords(int skip, int take);
    }
}
