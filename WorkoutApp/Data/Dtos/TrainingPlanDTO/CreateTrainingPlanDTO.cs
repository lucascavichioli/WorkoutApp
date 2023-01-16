namespace WorkoutApp.Data.Dtos
{
    public class CreateTrainingPlanDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int Author { get; set; } //reference

        public string? ImageLink { get; set; }

        public short Length { get; set; } //quantas semanas

        public short PerWeek { get; set; } //quantos dias por semana

        public short PerSession { get; set; } //quantos minutos por sessão de treino

        public int Category { get; set; } // Corrida / Cardio / HIIT reference

        public string? LocationDifficulty { get; set; } // reference

        public int Comments { get; set; }
        public int Likes { get; set; }
    }
}
