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
        public int DurationMinutes { get; set; } //minutes

        public int Sets { get; set; }
        public int Reps { get; set; } //refatorar para deixar dinamico
        public string? LinkVideo { get; set; }
        public int RestSeconds { get; set; } //descanso em segundos

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid TraceId { get; set; }

        public virtual List<TrainingExercises> TrainingExercises { get; set; }
    }
}
