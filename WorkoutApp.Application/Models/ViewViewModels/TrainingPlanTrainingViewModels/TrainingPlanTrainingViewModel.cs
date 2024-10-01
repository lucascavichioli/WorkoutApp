using WorkoutApp.Core.Entities;

namespace WorkoutApp.Application.Models.ViewViewModels.TrainingPlanTrainingViewModels
{
    public class TrainingPlanTrainingViewModel
    {
        public TrainingPlanTrainingViewModel(Guid trainingPlanFK, Guid trainingFK, int order, 
                                             int dayOfWeek)
        {
            TrainingPlanFK = trainingPlanFK;
            TrainingFK = trainingFK;
            Order = order;
            DayOfWeek = dayOfWeek;
        }
        public Guid Id { get; set; }
        public Guid TrainingPlanFK { get; set; }
        public Guid TrainingFK { get; set; }
        public int Order { get; set; }

        public int DayOfWeek { get; set; }

        public Training Training { get; set; } // infos do treino

        public static TrainingPlanTrainingViewModel FromEntity(TrainingPlanTraining trainingPlanTraining)
           => new(trainingPlanTraining.TrainingPlanFK, trainingPlanTraining.TrainingFK,
                  trainingPlanTraining.Order, trainingPlanTraining.DayOfWeek);
    }
}
