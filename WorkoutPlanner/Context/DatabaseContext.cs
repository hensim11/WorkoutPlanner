using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkoutPlanner.Model;

namespace WorkoutPlanner.Context
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        private IWebHostEnvironment _environment;
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutLog> WorkoutLogs { get; set; }
        public DbSet<PersonalTrainer> PersonalTrainers { get; set; }
        public DbSet<WeekPlan> WeekPlans { get; set; }
        public DbSet<DayPlan> DayPlans { get; set; }


        public DatabaseContext(DbContextOptions<DatabaseContext> options, IWebHostEnvironment environment) : base(options)
        {
            _environment = environment;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define the relationship between Workout and User
            modelBuilder.Entity<Workout>()
                .HasOne(w => w.User) // A Workout has one User
                .WithMany(u => u.Workouts) // A User can have many Workouts
                .HasForeignKey(w => w.UserId);

            modelBuilder.Entity<WeekPlan>()
            .HasMany(wp => wp.Days)
            .WithOne(dp => dp.WeekPlan)
            .HasForeignKey(dp => dp.WeekPlanId)
            .OnDelete(DeleteBehavior.Cascade); // Ensure cascading deletes

            modelBuilder.Entity<DayPlan>()
                .HasMany(dp => dp.Workouts)
                .WithOne(w => w.DayPlan)
                .HasForeignKey(w => w.DayPlanId)
                .OnDelete(DeleteBehavior.Cascade); // Ensure cascading deletes
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            var folder = Path.Combine(_environment.WebRootPath, "database");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            optionbuilder.UseSqlite($"Data Source={folder}/WorkoutPlanner.db");
        }
    }
}
