using DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IWebAppDataRepository
    {
        Task<List<WebAppData>> GetAllAsync();
    }
}
