using WorkoutApp.Application.Models;
using WorkoutApp.Application.Models.InputViewModels.ExercisesInputModels;
using WorkoutApp.Application.Models.ViewViewModels.ExercisesViewModels;

namespace WorkoutApp.Application.Services.Exercises
{
    public interface IExerciseService
    {
        Task<ResultViewModel<List<ExercisesViewModel>>> GetAllAsync(int skip = 0, int take = 50);
        Task<ResultViewModel<ExercisesViewModel>> GetByIdAsync(Guid id);
        Task<ResultViewModel<Guid>> AddAsync(CreateExercisesInputModel model);
        Task<ResultViewModel> Update(Guid id, UpdateExercisesInputModel model);
        Task<ResultViewModel> Delete(Guid id);
    }
}
