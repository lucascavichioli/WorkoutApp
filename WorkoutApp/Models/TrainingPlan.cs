using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WorkoutApp.Models
{
    public class TrainingPlan
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Author { get; set; } //reference

        [StringLength(255)]
        public string? ImageLink { get; set; }

        public short Length { get; set; } //quantas semanas

        public short PerWeek { get; set; } //quantos dias por semana

        public short PerSession { get; set; } //quantos minutos por sessão de treino

        public int Category { get; set; } // Corrida / Cardio / HIIT reference

        [StringLength(50)]
        public string? LocationDifficulty { get; set; } // reference

        public int Comments { get; set; } 
        public int Likes { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid TraceId { get; set; }

        [JsonIgnore]
        public virtual TrainingPlanTraining TrainingPlanTraining { get; set; }

    }
}
