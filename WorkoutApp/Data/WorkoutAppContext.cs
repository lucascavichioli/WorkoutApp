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
            builder.Entity<TrainingPlanTraining>()
                .HasOne(trainingPlanTraining => trainingPlanTraining.TrainingPlan)
                .WithMany(trainingPlan => trainingPlan.TrainingPlanTraining)
                .HasForeignKey(trainingPlanTraining => trainingPlanTraining.TrainingPlanFK);

            builder.Entity<TrainingPlanTraining>()
                .HasOne(training => training.Training)
                .WithMany(trainingPlanTraining => trainingPlanTraining.TrainingPlanTraining)
                .HasForeignKey(trainingPlanTraining => trainingPlanTraining.TrainingFK);

            builder.Entity<TrainingExercises>()
                .HasOne(trainingExercises => trainingExercises.Training)
                .WithMany(training => training.TrainingExercises)
                .HasForeignKey(trainingExercises => trainingExercises.TrainingFK);
            
            builder.Entity<TrainingExercises>()
                .HasOne(trainingExercises => trainingExercises.Exercises)
                .WithMany(exercises => exercises.TrainingExercises)
                .HasForeignKey(trainingExercises => trainingExercises.ExercisesFK);

        }

        public DbSet<TrainingPlan> TrainingPlan {get; set;}
        public DbSet<Training> Training { get; set; }
        public DbSet<TrainingPlanTraining> TrainingPlanTraining { get; set; }
        public DbSet<TrainingExercises> TrainingExercises { get; set; }
        public DbSet<Exercises> Exercises { get; set; }
    }
}
