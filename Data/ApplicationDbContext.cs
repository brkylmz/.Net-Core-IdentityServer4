using _Net_Core_IdentityServer4.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _Net_Core_IdentityServer4.Data
{

    public class ApplicationDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("User");
            builder.Entity<Role>().ToTable("Role");
            builder.Entity<UserRole>().ToTable("UserRole");
            builder.Entity<RoleClaim>().ToTable("RoleClaim");
            builder.Entity<UserClaim>().ToTable("UserClaim");
            builder.Entity<UserToken>().ToTable("UserToken");
            builder.Entity<UserLogin>().ToTable("UserLogin");
        }
    }
}