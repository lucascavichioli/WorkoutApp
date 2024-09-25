using WorkoutApp.Core.Entities;

namespace WorkoutApp.Application.Models.ViewViewModels.ExercisesViewModels
{
    public class ExercisesViewModel : ResultViewModel
    {
        public ExercisesViewModel(string title, string description, string? linkVideo)
        {
            Title = title;
            Description = description;
            LinkVideo = linkVideo;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string? LinkVideo { get; set; }

        public static ExercisesViewModel FromEntity(Exercises exercises)
            => new(exercises.Title, exercises.Description, exercises.LinkVideo);
    }
}
