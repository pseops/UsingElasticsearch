using DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.AppContext
{
    public class ApplicationContext : IdentityDbContext<AppUser>
    {
        public DbSet<WebAppData> WebAppDatas { get; set; }
        public DbSet<LogException> LogExceptions { get; set; }
        public DbSet<UsersPermission> UsersPermissions { get; set; }



        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
