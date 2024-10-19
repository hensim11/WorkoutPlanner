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

        public ICollection<WorkoutLog> WorkoutLogs { get; set; }

        public ICollection<Favourite> Favourites { get; set; }
    }
}
