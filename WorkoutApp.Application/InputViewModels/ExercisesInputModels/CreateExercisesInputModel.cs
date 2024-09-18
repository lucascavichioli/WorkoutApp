using WorkoutApp.Core.Entities;

namespace WorkoutApp.Application.InputViewModels.ExercisesInputModels
{
    public class CreateExercisesInputModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? LinkVideo { get; set; }

        public Exercises ToEntity() => new(Title, Description, LinkVideo);
    }
}
