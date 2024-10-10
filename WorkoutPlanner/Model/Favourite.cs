namespace WorkoutPlanner.Model
{
    public class Favourite
    {
        // Primary key for the Favourite table
        public int Id { get; set; }

        // Foreign key to Workout
      
        // Navigation properties for the relationships
        public Workout Workout { get; set; }
        public User User { get; set; }
    }
}
