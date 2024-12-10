using WorkoutPlanner.Model;

namespace WorkoutPlanner.Context
{
    public class WorkoutPlanProvider
    {
        private readonly WorkoutProvider _workoutProvider;

        public WorkoutPlanProvider(WorkoutProvider workoutProvider)
        {
            _workoutProvider = workoutProvider;
        }

        public async Task<List<WeekPlan>> GenerateWorkoutPlanAsync(string userId, int daysAvailable)
        {
            var workouts = await _workoutProvider.GetWorkoutsForUserAsync(userId);
            var weekPlans = new List<WeekPlan>();

            for (int week = 1; week <= 4; week++)
            {
                var dailyPlan = new List<DayPlan>();
                var workoutDays = GenerateWorkoutDays(daysAvailable);

                for (int day = 1; day <= 7; day++)
                {
                    if (workoutDays.Contains(day))
                    {
                        var randomWorkouts = workouts.OrderBy(_ => Guid.NewGuid()).Take(5).ToList();
                        dailyPlan.Add(new DayPlan { DayNumber = day, IsRestDay = false, Workouts = randomWorkouts });
                    }
                    else
                    {
                        dailyPlan.Add(new DayPlan { DayNumber = day, IsRestDay = true });
                    }
                }

                weekPlans.Add(new WeekPlan { WeekNumber = week, Days = dailyPlan });
            }

            return weekPlans;
        }

        private List<int> GenerateWorkoutDays(int daysAvailable)
        {
            var days = Enumerable.Range(1, 7).OrderBy(_ => Guid.NewGuid()).Take(daysAvailable).ToList();
            return days;
        }
    }

    public class WeekPlan
    {
        public int WeekNumber { get; set; }
        public List<DayPlan> Days { get; set; }
    }

    public class DayPlan
    {
        public int DayNumber { get; set; }
        public bool IsRestDay { get; set; }
        public List<Workout> Workouts { get; set; }
    }

}
