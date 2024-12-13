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

        public async Task<List<Workout>> GetWorkoutsForUserAsync(string userId)
        {
            return await _context.Workouts
                .Where(w => w.UserId == userId) // Filter by user
                .ToListAsync();
        }

        public async Task AssignRandomWorkoutsToUserAsync(string userId, int count)
        {
            // Get all workouts from the shared pool
            var allWorkouts = await _context.Workouts.ToListAsync();

            // Randomly select workouts (ensure no duplicates for the user)
            var randomWorkouts = allWorkouts
                .OrderBy(_ => Guid.NewGuid()) // Shuffle workouts
                .Take(count) // Take the desired number
                .Select(w => new Workout
                {
                    ExerciseName = w.ExerciseName,
                    Reps = w.Reps,
                    Sets = w.Sets,
                    Weight = w.Weight,
                    RestTime = w.RestTime,
                    ExerciseInfo = w.ExerciseInfo,
                    UserId = userId // Link to the new user
                })
                .ToList();

            // Add the random workouts to the database
            await _context.Workouts.AddRangeAsync(randomWorkouts);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateWorkoutAsync(Workout updatedWorkout)
        {
            // Retrieve the existing workout record from the database by its ID.
            var existingWorkout = await _context.Workouts.FindAsync(updatedWorkout.Id);

            // Check if the workout exists in the database.
            if (existingWorkout != null)
            {
                // Update the existing workout properties with the new values.
                existingWorkout.ExerciseName = updatedWorkout.ExerciseName;
                existingWorkout.Reps = updatedWorkout.Reps;
                existingWorkout.Sets = updatedWorkout.Sets;
                existingWorkout.Weight = updatedWorkout.Weight;

                // Save changes to the database.
                await _context.SaveChangesAsync();
            }
            
        }
    }

}