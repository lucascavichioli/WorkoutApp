using Microsoft.EntityFrameworkCore;
using WorkoutApp.Application.Models;
using WorkoutApp.Application.Models.InputViewModels.ExercisesInputModels;
using WorkoutApp.Application.Models.ViewViewModels.ExercisesViewModels;
using WorkoutApp.Infrastructure.Persistence;

namespace WorkoutApp.Application.Services.Exercises
{
    public class ExerciseService : IExerciseService
    {
        private readonly WorkoutAppContext _context;

        public ExerciseService(WorkoutAppContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<List<ExercisesViewModel>>> GetAllAsync(int skip = 0, int take = 50)
        {
            var exercises = await _context.Exercises.Skip(skip).Take(take).ToListAsync();
            var model = exercises.Select(ExercisesViewModel.FromEntity).ToList();
            return ResultViewModel<List<ExercisesViewModel>>.Success(model);
        }

        public async Task<ResultViewModel<ExercisesViewModel>> GetByIdAsync(Guid id)
        {
            var exercise = await _context.Exercises.SingleOrDefaultAsync(e => e.Id == id);
            if (exercise is null)
                return ResultViewModel<ExercisesViewModel>.Error("Exercício não existe");
            
            var model = ExercisesViewModel.FromEntity(exercise);
            
            return ResultViewModel<ExercisesViewModel>.Success(model);
        }
        public async Task<ResultViewModel<Guid>> AddAsync(CreateExercisesInputModel model)
        {
            var exercise = model.ToEntity();
            await _context.Exercises.AddAsync(exercise);
            await _context.SaveChangesAsync();
            return ResultViewModel<Guid>.Success(exercise.Id);
        }
        public async Task<ResultViewModel> Update(Guid id, UpdateExercisesInputModel model)
        {
            var exercise = await _context.Exercises.SingleOrDefaultAsync(e => e.Id == id);
            if (exercise is null)
                return ResultViewModel<ExercisesViewModel>.Error("Exercício não existe");

            exercise.Update(model.Title, model.Description, model.LinkVideo);
            _context.Exercises.Update(exercise);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }

        public async Task<ResultViewModel> Delete(Guid id)
        {
            var exercise = await _context.Exercises.SingleOrDefaultAsync(e => e.Id == id);
            if (exercise is null)
                return ResultViewModel<ExercisesViewModel>.Error("Exercício não existe");

            exercise.SetAsDeleted();
            _context.Exercises.Update(exercise);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
