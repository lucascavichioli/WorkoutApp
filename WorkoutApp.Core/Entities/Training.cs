using System.Text.Json.Serialization;

namespace WorkoutApp.Core.Entities
{
    public class Training : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public short DurationMinutes { get; set; } //minutes
        public virtual List<TrainingPlanTraining> TrainingPlanTraining { get; set; }
        public virtual List<TrainingExercises> TrainingExercises { get; set; }
        public int Likes { get; set; }
        public int Comments { get; set; }

        public Training(string title, string description, short durationMinutes, int likes, int comments) 
            : base()
        {
            Title = title;
            Description = description;
            DurationMinutes = durationMinutes;
            Likes = likes;
            Comments = comments;
            UpdatedAt = DateTime.Now;
        }

        public void Update(string title, string description, short durationMinutes, int likes, int comments)
        {
            Title = title;
            Description = description;
            DurationMinutes = durationMinutes;
            Likes = likes;  
            Comments = comments;
        }
    }
}
