using Microsoft.EntityFrameworkCore;
using WorkoutApp.Models;

namespace WorkoutApp.Data
{
    public class WorkoutAppContext : DbContext
    {

        public WorkoutAppContext(DbContextOptions<WorkoutAppContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Training>()
                .HasOne(training => training.TrainingPlan)
                .WithMany(trainingPlan => trainingPlan.Training)
                .HasForeignKey(training => training.TrainingPlanFK);
        }

        public DbSet<TrainingPlan> TrainingPlan {get; set;}
        public DbSet<Training> Training { get; set; }
    }
}
