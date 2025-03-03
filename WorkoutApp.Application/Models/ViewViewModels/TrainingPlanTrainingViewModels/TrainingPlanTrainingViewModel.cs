using WorkoutApp.Application.Models.ViewViewModels.TrainingViewModels;
using WorkoutApp.Core.Entities;

namespace WorkoutApp.Application.Models.ViewViewModels.TrainingPlanTrainingViewModels
{
    public class TrainingPlanTrainingViewModel
    {
        public TrainingPlanTrainingViewModel(Guid id, Guid trainingPlanFK, Guid trainingFK, int order, 
                                             int dayOfWeek, Training training)
        {
            Id = id;
            TrainingPlanFK = trainingPlanFK;
            TrainingFK = trainingFK;
            Order = order;
            DayOfWeek = dayOfWeek;
            Training = TrainingViewModel.FromEntity(training);
        }
        public Guid Id { get; set; }
        public Guid TrainingPlanFK { get; set; }
        public Guid TrainingFK { get; set; }
        public int Order { get; set; }
        public int DayOfWeek { get; set; }

        public TrainingViewModel Training { get; set; }

        public static TrainingPlanTrainingViewModel FromEntity(TrainingPlanTraining trainingPlanTraining)
           => new(trainingPlanTraining.Id, trainingPlanTraining.TrainingPlanFK, trainingPlanTraining.TrainingFK, 
                  trainingPlanTraining.Order, trainingPlanTraining.DayOfWeek, trainingPlanTraining.Training);
    }
}
