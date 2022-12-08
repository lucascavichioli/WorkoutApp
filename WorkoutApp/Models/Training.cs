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

        public short Duration { get; set; } //minutes

        public virtual TrainingPlan TrainingPlan { get; set; }
        public Guid TrainingPlanFK { get; set; }

        public int Likes { get; set; }
        public string? Comments { get; set; }
    }
}
