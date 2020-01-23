using DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> UpdateUserAsync(AppUser applicationUser);
        Task<AppUser> FindUserByIdAsync(string id);
        Task<bool> CreateUserAsync(AppUser applicationUser);
        Task SignInUserAsync(AppUser user);
        Task<AppUser> FindUserByEmailAsync(string email);
        Task<bool> PasswordCheckAsync(string userName, string password);
        Task<List<string>> GetUserRole(AppUser user);
        Task<bool> AddToRole(AppUser user, string role);
        Task<List<AppUser>> GetAll();

    }
}
