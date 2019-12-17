using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityResult> UpdateUserAsync(AppUser applicationUser);
        Task<AppUser> FindUserByIdAsync(string id);
        Task<IdentityResult> CreateUserAsync(AppUser applicationUser, string password);
        Task SignInUserAsync(AppUser user);
        Task<AppUser> FindUserByEmailAsync(string email);
    }
}
