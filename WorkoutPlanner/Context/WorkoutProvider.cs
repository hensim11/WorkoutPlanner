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

            public async Task<List<Workout>> GetAllWorkoutsAsync()
            {
                return await _context.Workouts.OrderBy(workout => workout.ExerciseName).ToListAsync();
            }

            public Workout? GetWorkout(int id)
            {
                return _context.Workouts.Find(id);
            }
        
    }
}
