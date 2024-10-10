namespace WorkoutPlanner.Model
{
    public class PersonalTrainer
    {
        // Primary key for the PersonalTrainer table
        public int Id { get; set; }

        // Foreign key, relates to User (each trainer is assigned to a user)
 

        // Trainer's personal information
        public string FirstName { get; set; }
        public string LastName { get; set; }
   
        // Navigation property to the related users
        public ICollection<User> Users { get; set; }
    }
}
