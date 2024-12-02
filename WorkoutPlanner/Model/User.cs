using Microsoft.AspNetCore.Identity;

namespace WorkoutPlanner.Model
{
    public class User : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        // User's fitness information
        
        public string Goal { get; set; }

        public string FitnessLevel { get; set; }    

        public double Weight { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public int DaysAvailable { get; set; }  
        public TimeSpan WorkoutLength { get; set; }  

        
        public PersonalTrainer? PersonalTrainers { get; set; }

        public ICollection<Workout> Workouts { get; set; }

        // Navigation property to the related workout logs
        public ICollection<WorkoutLog>? WorkoutLogs { get; set; }

        // Navigation property to the related favorite workouts
        public ICollection<Favourite>? Favourites { get; set; }
    }
}
