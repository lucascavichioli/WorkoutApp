using System.ComponentModel.DataAnnotations;

namespace WorkoutApp.Models
{
    public class TrainingExercises
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        public virtual Training Training { get; set; }
        [Required]
        public Guid TrainingFK { get; set; }
        public virtual Exercises Exercises { get; set; }
        [Required]
        public Guid ExercisesFK { get; set; }

        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public int DurationMinutes { get; set; } // minutes
        public int Likes { get; set; }
        public int Comments { get; set; }

        public int Order { get; set; }
    }
}
