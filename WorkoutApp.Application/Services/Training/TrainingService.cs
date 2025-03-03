using Microsoft.EntityFrameworkCore;
using WorkoutApp.Application.Models;
using WorkoutApp.Application.Models.InputViewModels.TrainingInputModels;
using WorkoutApp.Application.Models.ViewViewModels.TrainingViewModels;
using WorkoutApp.Infrastructure.Persistence;

namespace WorkoutApp.Application.Services.Training
{
    public class TrainingService : ITrainingService
    {
        private readonly WorkoutAppContext _context;

        public TrainingService(WorkoutAppContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<List<TrainingViewModel>>> GetAllAsync(int skip = 0, int take = 50)
        {
            var training = await _context.Training.Skip(skip).Take(take).ToListAsync();
            var model = training.Select(TrainingViewModel.FromEntity).ToList();
            return ResultViewModel<List<TrainingViewModel>>.Success(model);
        }

        public async Task<ResultViewModel<TrainingViewModel>> GetByIdAsync(Guid id)
        {
            var training = await _context.Training.SingleOrDefaultAsync(e => e.Id == id);
            if (training is null)
                return ResultViewModel<TrainingViewModel>.Error("Treino não existe");
            
            var model = TrainingViewModel.FromEntity(training);
            
            return ResultViewModel<TrainingViewModel>.Success(model);
        }
        public async Task<ResultViewModel<Guid>> AddAsync(CreateTrainingInputModel model)
        {
            var training = model.ToEntity();
            await _context.Training.AddAsync(training);
            await _context.SaveChangesAsync();
            return ResultViewModel<Guid>.Success(training.Id);
        }
        public async Task<ResultViewModel> Update(Guid id, UpdateTrainingInputModel model)
        {
            var training = await _context.Training.AsNoTracking().SingleOrDefaultAsync(t => t.Id == id);
            if (training is null)
                return ResultViewModel<TrainingViewModel>.Error("Treino não existe");

            training.Update(model.Title, model.Description, model.DurationMinutes, model.Likes, model.Comments);
            _context.Training.Update(training);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }

        public async Task<ResultViewModel> Delete(Guid id)
        {
            var training = await _context.Training.SingleOrDefaultAsync(e => e.Id == id);
            if (training is null)
                return ResultViewModel<TrainingViewModel>.Error("Exercício não existe");

            training.SetAsDeleted();
            _context.Training.Update(training);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
