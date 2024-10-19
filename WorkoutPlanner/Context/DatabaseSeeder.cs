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
            await _context.Database.MigrateAsync();

            if (!_context.Users.Any())
            {
                // Create roles for PersonalTrainer and Client
                await _roleManager.CreateAsync(new IdentityRole("PersonalTrainer"));
                await _roleManager.CreateAsync(new IdentityRole("Client"));

                // Create PersonalTrainer user
                var trainerEmail = "trainer@fitness.com";
                var trainerPassword = "Trainer123!";
                var personalTrainer = new User
                {
                    Email = trainerEmail,
                    FirstName = "John",
                    LastName = "Doe",
                };
                await _userManager.CreateAsync(personalTrainer, trainerPassword);
                await _userManager.AddToRoleAsync(personalTrainer, "PersonalTrainer");

                // Create Client user
                var clientEmail = "client@fitness.com";
                var clientPassword = "Client123!";
                var client = new User
                {
                    Email = clientEmail,
                    FirstName = "Jane",
                    LastName = "Smith",
                };
                await _userManager.CreateAsync(client, clientPassword);
                await _userManager.AddToRoleAsync(client, "Client");
            }
        }
    }
}
