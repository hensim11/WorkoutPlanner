namespace WorkoutPlanner.Model
{
    public class WorkoutLog
    {
        // Primary key for the WorkoutLog table
        public int Id { get; set; }

        // Foreign keys to Workout and User tables
       

        // Navigation properties for the relationships
        public Workout Workout { get; set; }
        public User User { get; set; }
    }
}
