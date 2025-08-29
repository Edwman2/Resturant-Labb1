using Microsoft.AspNetCore.Identity;
using Resturant_Labb1.Models;

namespace Resturant_Labb1.Data
{
    public class DbInitializer
    {
        public static void Initialize(ResturantDbContext context, IConfiguration config)
        {
            context.Database.EnsureCreated();

            if (context.Admins.Any())
                return;

            var adminUsername = config["AdminSettings:Username"];
            var adminPassword = config["AdminSettings:Password"];
            var adminRole = config["AdminSettings:Role"];

            var passwordHasher = new PasswordHasher<Admin>();

            var admin = new Admin
            {
                Username = adminUsername,
                Role = adminRole
            };

            admin.PasswordHash = passwordHasher.HashPassword(admin, adminPassword);

            context.Admins.Add(admin);
            context.SaveChangesAsync();
        }
    }
}
