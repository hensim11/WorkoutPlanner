namespace WorkoutPlanner.Model
{
    public class PersonalTrainer
    {
        public int Id { get; set; }

 

        public string FirstName { get; set; }
        public string LastName { get; set; }
   
        public ICollection<User> Users { get; set; }
    }
}
