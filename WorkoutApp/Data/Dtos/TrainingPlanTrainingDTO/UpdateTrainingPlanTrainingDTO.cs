namespace WorkoutApp.Data.Dtos
{
    public class UpdateTrainingPlanTrainingDTO
    {
        public Guid TrainingPlanFK { get; set; }
        public Guid TrainingFK { get; set; }

        public int Order { get; set; }

        public int DayOfWeek { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Guid TraceId { get; set; }
    }
}
