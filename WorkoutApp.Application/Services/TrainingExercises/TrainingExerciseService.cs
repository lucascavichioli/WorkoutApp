using Microsoft.EntityFrameworkCore;
using WorkoutApp.Application.Models;
using WorkoutApp.Application.Models.InputViewModels.TrainingExerciseInputModels;
using WorkoutApp.Application.Models.ViewViewModels.TrainingExerciseViewModels;
using WorkoutApp.Infrastructure.Persistence;

namespace WorkoutApp.Application.Services.TrainingExercises
{
    public class TrainingExerciseService : ITrainingExerciseService
    {
        private readonly WorkoutAppContext _context;

        public TrainingExerciseService(WorkoutAppContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<List<TrainingExerciseViewModel>>> GetAllAsync(int skip = 0, int take = 50)
        {
            var trainingExercise = await _context.TrainingExercises.Skip(skip).Take(take).ToListAsync();
            var model = trainingExercise.Select(TrainingExerciseViewModel.FromEntity).ToList();
            return ResultViewModel<List<TrainingExerciseViewModel>>.Success(model);
        }

        public async Task<ResultViewModel<TrainingExerciseViewModel>> GetByIdAsync(Guid id)
        {
            var trainingExercise = await _context.TrainingExercises.AsNoTracking().SingleOrDefaultAsync(e => e.Id == id);
            if (trainingExercise is null)
                return ResultViewModel<TrainingExerciseViewModel>.Error("Treino não existe");
            
            var model = TrainingExerciseViewModel.FromEntity(trainingExercise);
            
            return ResultViewModel<TrainingExerciseViewModel>.Success(model);
        }

        public async Task<ResultViewModel<List<TrainingExerciseViewModel>>> GetByTrainingIdAsync(Guid id)
        {
            var trainingExercise = await _context.TrainingExercises
                                        .Where(trainingExercise => trainingExercise.TrainingFK == id)
                                        .Select(x => TrainingExerciseViewModel.FromEntity(x))
                                        .ToListAsync();
            if (trainingExercise is null)
                return ResultViewModel<List<TrainingExerciseViewModel>>.Error("Treino Exercício não existe");

            return ResultViewModel<List<TrainingExerciseViewModel>>.Success(trainingExercise);
        }

        public async Task<ResultViewModel<Guid>> AddAsync(CreateTrainingExerciseInputModel model)
        {
            var trainingExercise = model.ToEntity();
            await _context.TrainingExercises.AddAsync(trainingExercise);
            await _context.SaveChangesAsync();
            return ResultViewModel<Guid>.Success(trainingExercise.Id);
        }
        public async Task<ResultViewModel> Update(Guid id, UpdateTrainingExerciseInputModel model)
        {
            var trainingExercise = await _context.TrainingExercises.SingleOrDefaultAsync(t => t.Id == id);
            if (trainingExercise is null)
                return ResultViewModel<TrainingExerciseViewModel>.Error("Treino não existe");

            trainingExercise.Update(model.TrainingFK, model.ExercisesFK, model.Title, 
                                    model.Description, model.DurationMinutes, model.Sets, 
                                    model.Reps, model.RestSeconds, model.Order);
            _context.TrainingExercises.Update(trainingExercise);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }

        public async Task<ResultViewModel> Delete(Guid id)
        {
            var trainingExercise = await _context.TrainingExercises.SingleOrDefaultAsync(e => e.Id == id);
            if (trainingExercise is null)
                return ResultViewModel<TrainingExerciseViewModel>.Error("Exercício não existe");

            trainingExercise.SetAsDeleted();
            _context.TrainingExercises.Update(trainingExercise);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
