namespace WorkoutPlanner.Model
{
    public class WorkoutLog
    {
        public int Id { get; set; }
        public int WorkoutId { get; set; } // Foreign key to the Workout table
        public string UserId { get; set; } // Foreign key to the User table
        public bool IsCompleted { get; set; } // Tracks if the workout was completed
        public DateTime CompletionDate { get; set; } // Timestamp for when the workout was completed

        // Navigation properties
        public Workout Workout { get; set; }
        public User User { get; set; }
    }
}
