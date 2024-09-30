using WorkoutApp.Application.Models;
using WorkoutApp.Application.Models.InputViewModels.TrainingInputModels;
using WorkoutApp.Application.Models.ViewViewModels.TrainingViewModels;

namespace WorkoutApp.Application.Services.Training
{
    public interface ITrainingService
    {
        Task<ResultViewModel<List<TrainingViewModel>>> GetAllAsync(int skip = 0, int take = 50);
        Task<ResultViewModel<TrainingViewModel>> GetByIdAsync(Guid id);
        Task<ResultViewModel<Guid>> AddAsync(CreateTrainingInputModel model);
        Task<ResultViewModel> Update(Guid id, UpdateTrainingInputModel model);
        Task<ResultViewModel> Delete(Guid id);
    }
}
