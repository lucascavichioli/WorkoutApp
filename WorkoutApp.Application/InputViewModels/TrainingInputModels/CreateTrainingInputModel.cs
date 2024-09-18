using WorkoutApp.Core.Entities;

namespace WorkoutApp.Application.InputViewModels.TrainingInputModels
{
    public class CreateTrainingInputModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public short DurationMinutes { get; set; }

        public int Likes { get; set; }
        public int Comments { get; set; }

        public Training ToEntity()
            => new(Title, Description, DurationMinutes, Likes, Comments);
    }
}
