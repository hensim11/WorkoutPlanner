using Microsoft.EntityFrameworkCore;
using WorkoutPlanner.Model;

namespace WorkoutPlanner.Context
{
    public class WorkoutPlanProvider
    {
        private readonly WorkoutProvider _workoutProvider;
        private readonly DatabaseContext _context;

        public WorkoutPlanProvider(WorkoutProvider workoutProvider, DatabaseContext context)
        {
            _workoutProvider = workoutProvider;
            _context = context;
        }

        public async Task<List<WeekPlan>> GenerateWorkoutPlanAsync(string userId, int daysAvailable)
        {
            // Check if the user already has a workout plan
            var existingPlans = await _context.WeekPlans
                .Include(wp => wp.Days)
                .ThenInclude(dp => dp.Workouts)
                .Where(wp => wp.UserId == userId) // Filter by UserId
                .ToListAsync();

            if (existingPlans.Any())
            {
                return existingPlans; // Return existing plans
            }

            // Generate a new workout plan (same logic as before)
            var allWorkouts = await _context.Workouts.ToListAsync();
            var random = new Random();
            var weekPlans = new List<WeekPlan>();

            for (int weekNumber = 1; weekNumber <= 4; weekNumber++)
            {
                var weekPlan = new WeekPlan
                {
                    UserId = userId, // Assign UserId
                    WeekNumber = weekNumber,
                    Days = new List<DayPlan>()
                };

                var workoutDays = GenerateWorkoutDays(daysAvailable);

                for (int dayNumber = 1; dayNumber <= 7; dayNumber++)
                {
                    if (workoutDays.Contains(dayNumber))
                    {
                        var selectedWorkouts = allWorkouts.OrderBy(_ => random.Next()).Take(5).ToList();
                        if (selectedWorkouts.Count < 5)
                        {
                            // Re-select workouts to ensure 5 are assigned
                            selectedWorkouts = allWorkouts.OrderBy(_ => Guid.NewGuid()).Take(5).ToList();
                        }

                        weekPlan.Days.Add(new DayPlan
                        {
                            DayNumber = dayNumber,
                            IsRestDay = false,
                            Workouts = selectedWorkouts
                        });
                    }
                    else
                    {
                        weekPlan.Days.Add(new DayPlan
                        {
                            DayNumber = dayNumber,
                            IsRestDay = true,
                            Workouts = new List<Workout>()
                        });
                    }
                }


                weekPlans.Add(weekPlan);
            }

            _context.WeekPlans.AddRange(weekPlans);
            await _context.SaveChangesAsync(); // Persist plans to the database

            return weekPlans;
        }


        private List<int> GenerateWorkoutDays(int daysAvailable)
        {
            return Enumerable.Range(1, 7)
                .OrderBy(_ => Guid.NewGuid()) // Randomize order
                .Take(daysAvailable) // Select workout days
                .ToList();
        }



    }



}
