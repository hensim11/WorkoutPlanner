namespace WorkoutPlanner.Model
{
    public class Workout
    {
        public int Id { get; set; }

        public int Reps { get; set; }
        public int Sets { get; set; }
        public decimal Weight { get; set; }  
        public int RestTime { get; set; }  

        public string ExerciseName { get; set; }
        public string ExerciseInfo { get; set; }
        public string? ImageUrl { get; set; }

        public string? UserId { get; set; } 
        public User? User { get; set; } // For navigation

        // Foreign key to DayPlan
        public int? DayPlanId { get; set; } // Nullable to support shared workouts
        public DayPlan DayPlan { get; set; } // Navigation property

    }
}
