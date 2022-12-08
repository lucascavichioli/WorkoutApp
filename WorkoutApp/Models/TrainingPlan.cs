using System.ComponentModel.DataAnnotations;

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

        public string? ImageLink { get; set; }

        public short Length { get; set; } //quantas semanas

        public short PerWeek { get; set; } //quantos dias por semana

        public short PerSession { get; set; } //quantos minutos por sessão de treino

        public int Category { get; set; } // Corrida / Cardio / HIIT reference

        public string? LocationDifficulty { get; set; } // reference

        public string? Comments { get; set; } 
        public int Likes { get; set; }

        public virtual List<Training> Training { get; set; }

    }
}
