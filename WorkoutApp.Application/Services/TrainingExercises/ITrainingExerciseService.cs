using WorkoutApp.Application.Models;
using WorkoutApp.Application.Models.InputViewModels.TrainingExerciseInputModels;
using WorkoutApp.Application.Models.ViewViewModels.TrainingExerciseViewModels;

namespace WorkoutApp.Application.Services.TrainingExercises
{
    public interface ITrainingExerciseService
    {
        Task<ResultViewModel<List<TrainingExerciseViewModel>>> GetAllAsync(int skip = 0, int take = 50);
        Task<ResultViewModel<TrainingExerciseViewModel>> GetByIdAsync(Guid id);

        Task<ResultViewModel<List<TrainingExerciseViewModel>>> GetByTrainingIdAsync(Guid id);
        Task<ResultViewModel<Guid>> AddAsync(CreateTrainingExerciseInputModel model);
        Task<ResultViewModel> Update(Guid id, UpdateTrainingExerciseInputModel model);
        Task<ResultViewModel> Delete(Guid id);
    }
}
