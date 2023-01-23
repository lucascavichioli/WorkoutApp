using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace WorkoutApp.Models
{
    public class Training
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public short DurationMinutes { get; set; } //minutes

        [JsonIgnore]
        public virtual List<TrainingPlanTraining> TrainingPlanTraining { get; set; }

        [JsonIgnore]
        public virtual List<TrainingExercises> TrainingExercises { get; set; }

        public int Likes { get; set; }
        public int Comments { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid TraceId { get; set; }

    }
}
