using WorkoutApp.Core.Entities;

namespace WorkoutApp.Application.Models.ViewViewModels.TrainingExerciseViewModels
{
    public class TrainingExerciseViewModel
    {
        public TrainingExerciseViewModel(Guid id, Guid trainingFK, Guid exercisesFK, string title, 
                                         string description, int durationMinutes, int sets, 
                                         string reps, int restSeconds, int likes, 
                                         int comments, int order)
        {
            Id = id;
            TrainingFK = trainingFK;
            ExercisesFK = exercisesFK;
            Title = title;
            Description = description;
            DurationMinutes = durationMinutes;
            Sets = sets;
            Reps = reps;
            RestSeconds = restSeconds;
            Likes = likes;
            Comments = comments;
            Order = order;
        }
        public Guid Id { get; set; }
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

        public static TrainingExerciseViewModel FromEntity(TrainingExercises tExercise)
            => new(tExercise.Id, tExercise.TrainingFK, tExercise.ExercisesFK, tExercise.Title, 
                   tExercise.Description, tExercise.DurationMinutes, tExercise.Sets, 
                   tExercise.Reps, tExercise.RestSeconds, tExercise.Likes, 
                   tExercise.Comments, tExercise.Order);
    }
}
