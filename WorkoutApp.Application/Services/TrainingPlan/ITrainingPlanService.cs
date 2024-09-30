using WorkoutApp.Application.Models;
using WorkoutApp.Application.Models.InputViewModels.TrainingPlanInputModels;
using WorkoutApp.Application.Models.ViewViewModels.TrainingPlanViewModels;

namespace WorkoutApp.Application.Services.TrainingPlan
{
    public interface ITrainingPlanService
    {
        Task<ResultViewModel<List<TrainingPlanViewModel>>> GetAllAsync(int skip = 0, int take = 50);
        Task<ResultViewModel<TrainingPlanViewModel>> GetByIdAsync(Guid id);
        Task<ResultViewModel<Guid>> AddAsync(CreateTrainingPlanInputModel model);
        Task<ResultViewModel> Update(Guid id, UpdateTrainingPlanInputModel model);
        Task<ResultViewModel> Delete(Guid id);
    }
}
