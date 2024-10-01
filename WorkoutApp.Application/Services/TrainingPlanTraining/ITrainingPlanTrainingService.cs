using WorkoutApp.Application.Models;
using WorkoutApp.Application.Models.InputViewModels.TrainingPlanTrainingInputModels;
using WorkoutApp.Application.Models.ViewViewModels.TrainingPlanTrainingViewModels;

namespace WorkoutApp.Application.Services.TrainingPlanTraining
{
    public interface ITrainingPlanTrainingService
    {
        Task<ResultViewModel<List<TrainingPlanTrainingViewModel>>> GetAllAsync(int skip = 0, int take = 50);
        Task<ResultViewModel<TrainingPlanTrainingViewModel>> GetByIdAsync(Guid id);
        Task<ResultViewModel<List<TrainingPlanTrainingViewModel>>> GetByTrainingPlanIdAsync(Guid id);
        Task<ResultViewModel<Guid>> AddAsync(CreateTrainingPlanTrainingInputModel model);
        Task<ResultViewModel> Update(Guid id, UpdateTrainingPlanTrainingInputModel model);
        Task<ResultViewModel> Delete(Guid id);
    }
}
