using WorkoutApp.Core.Entities;

namespace WorkoutApp.Application.Models.InputViewModels.TrainingExerciseInputModels
{
    public class UpdateTrainingExerciseInputModel
    {
        public Guid TrainingFK { get; set; }
        public Guid ExercisesFK { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int DurationMinutes { get; set; } // minutes
        public int Sets { get; set; }
        public string Reps { get; set; } //refatorar para deixar dinamico

        public int RestSeconds { get; set; } //descanso em segundos
        public int Likes { get; set; }
        public int Comments { get; set; }
        public int Order { get; set; }

        public TrainingExercises ToEntity()
            => new(TrainingFK, ExercisesFK, Title,
                    Description, DurationMinutes, Sets,
                    Reps, RestSeconds, Likes,
                    Comments, Order);

    }
}
