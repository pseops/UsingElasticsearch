using DataAccess.AppContext;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Initialization
{
    public class DbInitializer
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationContext _context;

        public DbInitializer(UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager, ApplicationContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }
        public void SeedData()
        {
            SeedRoles();
            SeedAdmin();
        }

        private async void SeedAdmin()
        {
            if (await _userManager.FindByNameAsync("admin") != null)
            {
                return;
            }

            var user = new AppUser();
            user.UserName = "admin";
            user.Email = "admin@admin";
            user.FirstName = "Admin";
            user.LastName = "Adminov";
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            user.Password = "admin";

            var result = await _userManager.CreateAsync(user, "admin");

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "admin");
            }

        }

        public async void SeedRoles()
        {
            if ( !await _roleManager.RoleExistsAsync("admin"))
            {
                var role = new IdentityRole();
                role.Name = "admin";
                await _roleManager.CreateAsync(role);
            }


            if (!await _roleManager.RoleExistsAsync("user"))
            {
                var role = new IdentityRole();
                role.Name = "user";
                await _roleManager.CreateAsync(role);
            }
        }
       
    }
}

