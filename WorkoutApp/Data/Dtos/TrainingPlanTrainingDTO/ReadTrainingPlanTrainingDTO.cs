using WorkoutApp.Models;

namespace WorkoutApp.Data.Dtos
{
    public class ReadTrainingPlanTrainingDTO
    {
        public Guid Id { get; set; }
        public Guid TrainingPlanFK { get; set; }
        public Guid TrainingFK { get; set; }
        public int Order { get; set; }

        public int DayOfWeek { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Guid TraceId { get; set; }

        public Training Training { get; set; } // infos do treino
    }
}
