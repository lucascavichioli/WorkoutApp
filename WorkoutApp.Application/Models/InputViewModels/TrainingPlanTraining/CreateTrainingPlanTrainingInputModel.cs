using WorkoutApp.Core.Entities;

namespace WorkoutApp.Application.Models.InputViewModels.TrainingPlanTrainingInputModels
{
    public class CreateTrainingPlanTrainingInputModel
    {
        public Guid TrainingPlanFK { get; set; }
        public Guid TrainingFK { get; set; }

        public int Order { get; set; }

        public int DayOfWeek { get; set; }

        public TrainingPlanTraining ToEntity() => new(TrainingPlanFK, TrainingFK, Order, DayOfWeek);
    }
}
