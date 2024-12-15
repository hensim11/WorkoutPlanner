namespace WorkoutPlanner.Model
{
    public class Favourite
    {
        // Primary key for the Favourite table
        public int Id { get; set; }

        // Foreign key to Workout
        public int WorkoutId { get; set; }
        public string UserId { get; set; }

        // Navigation properties for the relationships
        public Workout Workout { get; set; }
        public User User { get; set; }
    }
}