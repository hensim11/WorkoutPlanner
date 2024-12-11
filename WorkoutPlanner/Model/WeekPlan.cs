using WorkoutPlanner.Context;

namespace WorkoutPlanner.Model
{
    public class WeekPlan
    {
        public int Id { get; set; }
        public int WeekNumber { get; set; } // e.g., 1, 2, 3, 4 for weeks
        public List<DayPlan> Days { get; set; } = new List<DayPlan>(); // Navigation property
    }
}
