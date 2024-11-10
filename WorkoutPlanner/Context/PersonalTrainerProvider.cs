using Microsoft.AspNetCore.Identity;
using WorkoutPlanner.Model;

namespace WorkoutPlanner.Context
{
    public class PersonalTrainerProvider
    {
        private User user;

        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;

        public PersonalTrainerProvider(DatabaseContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public User? GetUserByFirstName(string? name)
        {
            return _context.Users.FirstOrDefault(user => user.FirstName == name);
        }

        public async Task<User?> GetUserByIdAsync(string? id)
        {
            // Return the user with the id
            return await _context.Users.FindAsync(id);
        }

        public async Task<bool> IsPersonalTrainer(User user)
        {
            // Check if the user is a personal trainer
            return await _userManager.IsInRoleAsync(user, "PersonalTrainer");
        }
    }
}
