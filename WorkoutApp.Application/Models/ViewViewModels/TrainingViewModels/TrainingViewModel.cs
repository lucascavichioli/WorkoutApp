using WorkoutApp.Core.Entities;

namespace WorkoutApp.Application.Models.ViewViewModels.TrainingViewModels
{
    public class TrainingViewModel
    {
        public TrainingViewModel(string title, string description, short durationMinutes, int likes, int comments)
        {
            Title = title;
            Description = description;
            DurationMinutes = durationMinutes;
            Likes = likes;
            Comments = comments;
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public short DurationMinutes { get; set; } //minutes

        public int Likes { get; set; }
        public int Comments { get; set; }

        public static TrainingViewModel FromEntity(Training training)
            => new(training.Title, training.Description, training.DurationMinutes, training.Likes, training.Comments);
    }
}
