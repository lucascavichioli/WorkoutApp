namespace WorkoutApp.Data.Dtos
{
    public class UpdateExerciseDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? LinkVideo { get; set; }
        public int RestSeconds { get; set; } //descanso em segundos
    }
}
