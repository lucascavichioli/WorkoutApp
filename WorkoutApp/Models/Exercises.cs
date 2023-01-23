using System.ComponentModel.DataAnnotations;

namespace WorkoutApp.Models
{
    public class Exercises
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string? LinkVideo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid TraceId { get; set; }

        public virtual List<TrainingExercises> TrainingExercises { get; set; }
    }
}
