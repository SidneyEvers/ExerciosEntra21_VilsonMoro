using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EntityProjectNew.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var userId = "21256080-e85b-414b-9744-86869b7c47df";
            var adminId = "e8edd518-f454-4c6d-ac9e-c75325159bd7";

            var roles = new List<IdentityRole>
            {
                new IdentityRole()
                {
                    Name = "usuario",
                    NormalizedName = "usuario".ToUpper(),
                    Id = userId,
                    ConcurrencyStamp = adminId
                },
                new IdentityRole()
                {
                    Name = "admin",
                    NormalizedName = "admin".ToUpper(),
                    Id = adminId,
                    ConcurrencyStamp =adminId
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            var adminUser = new IdentityUser()
            {
                Id = adminId,
                UserName = "Sidney",
                Email = "sidney@gmail.com",
                NormalizedEmail = "sidney@gmail.com".ToUpper(),
                NormalizedUserName = "sidney".ToUpper(),
            };

            adminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(adminUser, "Sidney@1");

            builder.Entity<IdentityUser>().HasData(adminUser);

            var rolesAdministrador = new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>
                {
                    RoleId = adminId,
                    UserId = adminId,
                },
                new IdentityUserRole<string>
                {
                    RoleId = userId,
                    UserId = adminId,
                }
            };
            builder.Entity<IdentityUserRole<string>>().HasData(rolesAdministrador);
        }
    }
}
