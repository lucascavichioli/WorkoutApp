namespace WorkoutApp.Core.Entities
{
    public class Exercises : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? LinkVideo { get; set; }
        public virtual List<TrainingExercises> TrainingExercises { get; set; }

        protected Exercises(){}

        public Exercises(string title, string description, string? linkVideo)
            : base()
        {
            Title = title;
            Description = description;
            LinkVideo = linkVideo;
            UpdatedAt = DateTime.Now;
        }

        public void Update(string title, string description, string linkVideo)
        {
            Title = title;
            Description = description;
            LinkVideo = linkVideo;
        }
    }
}
