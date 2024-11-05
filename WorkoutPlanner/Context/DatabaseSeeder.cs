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
        }


        private List<Workout> GetWorkouts()
            {
                return
                [
                    new Workout { ExerciseName = "Push-Up", Reps = 15, Sets = 3, Weight = 0, RestTime = 60, ExerciseInfo = "A bodyweight exercise focusing on chest, triceps, and shoulders." },
                    new Workout { ExerciseName = "Squat", Reps = 12, Sets = 3, Weight = 50, RestTime = 90, ExerciseInfo = "A compound movement targeting quads, glutes, and hamstrings." },
                    new Workout { ExerciseName = "Lunge", Reps = 12, Sets = 3, Weight = 20, RestTime = 60, ExerciseInfo = "Targets quads, glutes, and stabiliser muscles." },
                    new Workout { ExerciseName = "Plank", Reps = 1, Sets = 3, Weight = 0, RestTime = 60, ExerciseInfo = "An isometric exercise to strengthen the core muscles." },
                    new Workout { ExerciseName = "Burpee", Reps = 10, Sets = 3, Weight = 0, RestTime = 90, ExerciseInfo = "A full-body exercise that combines a squat, push-up, and jump." },
                    new Workout { ExerciseName = "Deadlift", Reps = 8, Sets = 3, Weight = 80, RestTime = 120, ExerciseInfo = "Targets the lower back, hamstrings, and glutes." },
                    new Workout { ExerciseName = "Bench Press", Reps = 10, Sets = 3, Weight = 60, RestTime = 90, ExerciseInfo = "Works the chest, shoulders, and triceps." },
                    new Workout { ExerciseName = "Bicep Curl", Reps = 12, Sets = 3, Weight = 15, RestTime = 60, ExerciseInfo = "Isolates the bicep muscles for increased arm strength." },
                    new Workout { ExerciseName = "Tricep Dip", Reps = 10, Sets = 3, Weight = 0, RestTime = 60, ExerciseInfo = "Targets the triceps, often performed using parallel bars or a bench." },
                    new Workout { ExerciseName = "Shoulder Press", Reps = 10, Sets = 3, Weight = 30, RestTime = 90, ExerciseInfo = "Works the shoulders and triceps." },
                    new Workout { ExerciseName = "Leg Press", Reps = 12, Sets = 3, Weight = 100, RestTime = 90, ExerciseInfo = "Targets the quads, hamstrings, and glutes." },
                    new Workout { ExerciseName = "Pull-Up", Reps = 8, Sets = 3, Weight = 0, RestTime = 90, ExerciseInfo = "Works the back, biceps, and shoulders." },
                    new Workout { ExerciseName = "Chin-Up", Reps = 8, Sets = 3, Weight = 0, RestTime = 90, ExerciseInfo = "Targets the back and biceps, with an underhand grip." },
                    new Workout { ExerciseName = "Crunch", Reps = 15, Sets = 3, Weight = 0, RestTime = 60, ExerciseInfo = "Focuses on the upper abs." },
                    new Workout { ExerciseName = "Russian Twist", Reps = 20, Sets = 3, Weight = 10, RestTime = 60, ExerciseInfo = "Targets the oblique muscles and core." },
                    new Workout { ExerciseName = "Mountain Climber", Reps = 20, Sets = 3, Weight = 0, RestTime = 60, ExerciseInfo = "A full-body exercise that primarily works the core and shoulders." },
                    new Workout { ExerciseName = "Bicycle Crunch", Reps = 15, Sets = 3, Weight = 0, RestTime = 60, ExerciseInfo = "Targets the core and oblique muscles." },
                    new Workout { ExerciseName = "Lat Pulldown", Reps = 12, Sets = 3, Weight = 50, RestTime = 90, ExerciseInfo = "Works the lats, biceps, and middle back." },
                    new Workout { ExerciseName = "Chest Fly", Reps = 12, Sets = 3, Weight = 20, RestTime = 60, ExerciseInfo = "Isolates the chest muscles, focusing on the pecs." },
                    new Workout { ExerciseName = "Hip Thrust", Reps = 10, Sets = 3, Weight = 60, RestTime = 90, ExerciseInfo = "Targets the glutes, improving lower body strength." },
                    new Workout { ExerciseName = "Leg Raise", Reps = 12, Sets = 3, Weight = 0, RestTime = 60, ExerciseInfo = "Works the lower abs." },
                    new Workout { ExerciseName = "Calf Raise", Reps = 15, Sets = 3, Weight = 30, RestTime = 60, ExerciseInfo = "Strengthens the calf muscles." },
                    new Workout { ExerciseName = "Sit-Up", Reps = 15, Sets = 3, Weight = 0, RestTime = 60, ExerciseInfo = "Targets the core, primarily the abdominal muscles." },
                    new Workout { ExerciseName = "Incline Bench Press", Reps = 10, Sets = 3, Weight = 50, RestTime = 90, ExerciseInfo = "Focuses on the upper chest and shoulders." },
                    new Workout { ExerciseName = "Hammer Curl", Reps = 12, Sets = 3, Weight = 15, RestTime = 60, ExerciseInfo = "Targets both the biceps and forearms." },
                    new Workout { ExerciseName = "Face Pull", Reps = 12, Sets = 3, Weight = 25, RestTime = 60, ExerciseInfo = "Targets the rear delts, traps, and upper back." },
                ];
            }
    }
}
