using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserRepository(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> CreateUserAsync(AppUser applicationUser)
        {
            var result = await _userManager.CreateAsync(applicationUser, applicationUser.Password);

            return result.Succeeded;
        }

        public async Task<bool> UpdateUserAsync(AppUser applicationUser)
        {
            var result = await _userManager.UpdateAsync(applicationUser);
            return result.Succeeded;
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

        public async Task<List<string>> GetUserRole(AppUser user)
        {
            var roles = (await _userManager.GetRolesAsync(user)).ToList();

            return roles;
        }

        public async Task<bool> AddToRole(AppUser user, string role)
        {
            var result = await _userManager.AddToRoleAsync(user, role);

            return result.Succeeded;
        }

        public async Task<bool> PasswordCheckAsync(string userName, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, false, false);

            return result.Succeeded;
        }
    }
}
