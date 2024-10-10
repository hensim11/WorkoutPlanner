using Microsoft.AspNetCore.Identity;

namespace WorkoutPlanner.Model
{
    public class User : IdentityUser
    {
        // Primary key for the User table
        public int Id { get; set; }

        // Foreign key, relates to PersonalTrainer (PtID in the diagram)
     

        // User's personal information
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // User's fitness information
        public string FitnessLevel { get; set; }
        public string Goal { get; set; }
        public decimal Weight { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public decimal Height { get; set; }
        public int DaysAvailable { get; set; }  // Number of days per week the user is available for training
        public int WorkoutLength { get; set; }  // Length of the workout in minutes

        // Navigation property to the related PersonalTrainer
        public PersonalTrainer PersonalTrainer { get; set; }

        // Navigation property to the related workout logs
        public ICollection<WorkoutLog> WorkoutLogs { get; set; }

        // Navigation property to the related favorite workouts
        public ICollection<Favourite> Favourites { get; set; }
    }
}
