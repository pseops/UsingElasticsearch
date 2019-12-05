using DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interfaces
{
    public interface IWebAppDataService
    {
        Task<List<WebAppData>> GetAll();
    }
}
