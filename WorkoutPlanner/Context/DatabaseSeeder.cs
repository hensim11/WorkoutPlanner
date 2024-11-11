
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WorkoutPlanner.Model;
using WorkoutPlanner.Components;



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

            if (!_context.Quotes.Any())
            {
                var quotes = GetQuotes();
                _context.Quotes.AddRange(quotes);
                await _context!.SaveChangesAsync();
            }

            if (!_context.Workouts.Any())
            {
                var workouts = GetWorkouts();
                _context.Workouts.AddRange(workouts);
                await _context!.SaveChangesAsync();
            }




            if (!_context.Users.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole("Client"));
                await _roleManager.CreateAsync(new IdentityRole("PersonalTrainer"));
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

        private List<Quote> GetQuotes()
        {
            return
                [
                    new Quote { QuoteName = "Push yourself because no one else is going to do it for you." },
                    new Quote { QuoteName = "The only bad workout is the one that didn't happen." },
                    new Quote { QuoteName = "Train insane or remain the same." },
                    new Quote { QuoteName = "You don't have to be great to start, but you have to start to be great." },
                    new Quote { QuoteName = "No matter how slow you go, you're still lapping everyone on the couch." },
                    new Quote { QuoteName = "Sweat is just fat crying." },
                    new Quote { QuoteName = "Fitness is not about being better than someone else. It's about being better than you used to be." },
                    new Quote { QuoteName = "If it doesn’t challenge you, it doesn’t change you." },
                    new Quote { QuoteName = "Results happen over time, not overnight. Work hard, stay consistent, and be patient." },
                    new Quote { QuoteName = "The body achieves what the mind believes." },
                    new Quote { QuoteName = "The pain you feel today will be the strength you feel tomorrow." },
                    new Quote { QuoteName = "Don't stop when you're tired. Stop when you're done." },
                    new Quote { QuoteName = "You are stronger than you think." },
                    new Quote { QuoteName = "Your body can stand almost anything. It’s your mind that you have to convince." },
                    new Quote { QuoteName = "When you feel like quitting, think about why you started." },
                    new Quote { QuoteName = "Success is what comes after you stop making excuses." },
                    new Quote { QuoteName = "Strive for progress, not perfection." },
                    new Quote { QuoteName = "Strength doesn’t come from what you can do. It comes from overcoming the things you once thought you couldn’t." },
                    new Quote { QuoteName = "Motivation is what gets you started. Habit is what keeps you going." },
                    new Quote { QuoteName = "The hardest lift of all is lifting your butt off the couch." }
                ];
        }
    }
}
