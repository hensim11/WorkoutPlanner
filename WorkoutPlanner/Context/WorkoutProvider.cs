using Microsoft.EntityFrameworkCore;
using WorkoutPlanner.Model;

namespace WorkoutPlanner.Context
{
    public class WorkoutProvider
    {

        private readonly DatabaseContext _context;

        public WorkoutProvider(DatabaseContext context)
        {
            _context = context;
        }

        public async Task RandomWorkoutAsync(string userId, int numberOfWorkouts = 5)
        {
            // Fetch random workouts from the database
            var randomWorkouts = _context.Workouts
                .OrderBy(w => Guid.NewGuid()) // Randomize order
                .Take(numberOfWorkouts) // Select the specified number of workouts
                .ToList();

            // Assign the workouts to the user
            foreach (var workout in randomWorkouts)
            {
                _context.Workouts.Add(new Workout
                {
                    ExerciseName = workout.ExerciseName,
                    Reps = workout.Reps,
                    Sets = workout.Sets,
                    Weight = workout.Weight,
                    RestTime = workout.RestTime,
                    ExerciseInfo = workout.ExerciseInfo,
                    UserId = userId // Associate with the new user
                });
            }

            await _context.SaveChangesAsync();
        }


        public Workout? GetWorkout(int id)
        {
            return _context.Workouts.Find(id);
        }


       
    }
}