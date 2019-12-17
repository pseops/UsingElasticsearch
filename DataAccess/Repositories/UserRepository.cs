using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserRepository(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateUserAsync(AppUser applicationUser, string password)
        {
            var result = await _userManager.CreateAsync(applicationUser, password);

            return result;
        }

        public async Task<IdentityResult> UpdateUserAsync(AppUser applicationUser)
        {
            return await _userManager.UpdateAsync(applicationUser);
        }

        public async Task<AppUser> FindUserByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<AppUser> FindUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task SignInUserAsync(AppUser user)
        {
            await _signInManager.SignInAsync(user, false);
        }
    }
}
