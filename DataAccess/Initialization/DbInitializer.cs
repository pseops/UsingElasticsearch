using DataAccess.AppContext;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

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
        public async Task SeedData()
        {            
            await SeedRoles();
            await SeedAdmin();

        }

        private async Task SeedAdmin()
        {
            if (await _userManager.FindByNameAsync("Admin") != null)
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
                await _userManager.AddToRoleAsync(user, "Admin");
            }

        }

        public async Task SeedRoles()
        {
            if ( !await _roleManager.RoleExistsAsync("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                await _roleManager.CreateAsync(role);
            }


            if (!await _roleManager.RoleExistsAsync("User"))
            {
                var role = new IdentityRole();
                role.Name = "User";
                await _roleManager.CreateAsync(role);
            }
        }
       
    }
}

