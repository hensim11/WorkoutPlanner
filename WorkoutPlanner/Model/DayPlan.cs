namespace WorkoutPlanner.Model
{
    public class DayPlan
    {
        public int Id { get; set; }
        public int DayNumber { get; set; } // e.g., 1-7 for days of the week
        public bool IsRestDay { get; set; }
        public List<Workout> Workouts { get; set; } = new List<Workout>(); // Navigation property

        // Foreign key to WeekPlan
        public int WeekPlanId { get; set; } // Required foreign key
        public WeekPlan WeekPlan { get; set; } // Navigation property
    }
}
