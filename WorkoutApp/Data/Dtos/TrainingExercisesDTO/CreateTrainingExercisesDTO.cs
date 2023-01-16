namespace WorkoutApp.Data.Dtos
{
    public class CreateTrainingExercisesDTO
    {
        public Guid TrainingFK { get; set; }
        public Guid ExercisesFK { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int DurationMinutes { get; set; } // minutes
        public int Likes { get; set; }
        public int Comments { get; set; }
        public int Order { get; set; }

    }
}
