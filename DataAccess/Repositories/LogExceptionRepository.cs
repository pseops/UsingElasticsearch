using DataAccess.Entities;
using DataAccess.Repositories.Base;
using DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Repositories
{
    public class LogExceptionRepository : BaseRepository<LogException>, ILogExceptionRepository
    {
        public LogExceptionRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
