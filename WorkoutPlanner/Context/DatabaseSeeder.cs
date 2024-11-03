using Microsoft.AspNetCore.Authorization;
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
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("PersonalTrainer"));

                var adminEmail = "admin@workout.com";
                var adminPassword = "Workout123!";

                var admin = new User
                {
                    Email = adminEmail,
                    FirstName = "Admin",
                    LastName = "User",
                };
                
                await _userManager.CreateAsync(admin, adminPassword);
                await _userManager.AddToRoleAsync(admin, "Admin");
            }

            if (!_context.Workouts.Any())
            {
                var workouts = GetWorkouts();
                _context.Workouts.AddRange(workouts);
                await _context.SaveChangesAsync();



            }


            private List<Workout> GetWorkouts()
            {
                return
                [
                    new Workout { ExerciseName = "Push-Up" },
                    new Workout { ExerciseName = "Squat" },
                    new Workout { ExerciseName = "Lunge" },
                    new Workout { ExerciseName = "Plank" },
                    new Workout { ExerciseName = "Burpee" },
                    new Workout { ExerciseName = "Deadlift" },
                    new Workout { ExerciseName = "Bench Press" },
                    new Workout { ExerciseName = "Bicep Curl" },
                    new Workout { ExerciseName = "Tricep Dip" },
                    new Workout { ExerciseName = "Shoulder Press" },
                    new Workout { ExerciseName = "Leg Press" },
                    new Workout { ExerciseName = "Pull-Up" },
                    new Workout { ExerciseName = "Chin-Up" },
                    new Workout { ExerciseName = "Crunch" },
                    new Workout { ExerciseName = "Russian Twist" },
                    new Workout { ExerciseName = "Mountain Climber" },
                    new Workout { ExerciseName = "Bicycle Crunch" },
                    new Workout { ExerciseName = "Lat Pulldown" },
                    new Workout { ExerciseName = "Chest Fly" },
                    new Workout { ExerciseName = "Hip Thrust" },
                    new Workout { ExerciseName = "Leg Raise" },
                    new Workout { ExerciseName = "Calf Raise" },
                    new Workout { ExerciseName = "Sit-Up" },
                    new Workout { ExerciseName = "Incline Bench Press" },
                    new Workout { ExerciseName = "Hammer Curl" }
                ];
            }



        }
    }
}
