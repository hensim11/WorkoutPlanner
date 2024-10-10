namespace WorkoutPlanner.Model
{
    public class Workout
    {
        // Primary key for the Workout table
        public int Id { get; set; }

        // Details of the workout session
        public int Reps { get; set; }
        public int Sets { get; set; }
        public decimal Weight { get; set; }  // Weight in kilograms (or any preferred unit)
        public int RestTime { get; set; }  // Rest time in seconds between sets

        // Exercise details
        public string ExerciseName { get; set; }
        public string ExerciseInfo { get; set; }

        // Navigation property to the related workout logs
        public ICollection<WorkoutLog> WorkoutLogs { get; set; }

        // Navigation property to the related favourites
        public ICollection<Favourite> Favourites { get; set; }
    }
}
