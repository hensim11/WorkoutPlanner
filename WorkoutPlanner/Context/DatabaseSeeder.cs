using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WorkoutPlanner.Model;

namespace WorkoutPlanner.Context
{
    public class DatabaseSeeder
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DatabaseSeeder(DatabaseContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            // Apply pending migrations
            await _context.Database.MigrateAsync();

            // Check if roles exist, if not, create them
            if (!await _roleManager.RoleExistsAsync("PersonalTrainer"))
            {
                await _roleManager.CreateAsync(new IdentityRole("PersonalTrainer"));
            }

            if (!await _roleManager.RoleExistsAsync("Client"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Client"));
            }

            // Seed a Personal Trainer user
            if (!_context.Users.Any(u => u.UserName == "trainer@example.com"))
            {
                var personalTrainer = new User
                {
                    UserName = "trainer@example.com",
                    Email = "trainer@example.com",
                    // Add other necessary properties here
                };

                var result = await _userManager.CreateAsync(personalTrainer, "TrainerPassword123!");

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(personalTrainer, "PersonalTrainer");
                }
            }

            // Seed a Client user
            if (!_context.Users.Any(u => u.UserName == "client@example.com"))
            {
                var client = new User
                {
                    UserName = "client@example.com",
                    Email = "client@example.com",
                    
                };

                var result = await _userManager.CreateAsync(client, "ClientPassword123!");

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(client, "Client");
                }
            }
        }
    }
}
