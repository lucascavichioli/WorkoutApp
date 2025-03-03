using Microsoft.EntityFrameworkCore;
using WorkoutApp.Application.Models;
using WorkoutApp.Application.Models.InputViewModels.TrainingPlanInputModels;
using WorkoutApp.Application.Models.ViewViewModels.TrainingPlanViewModels;
using WorkoutApp.Infrastructure.Persistence;

namespace WorkoutApp.Application.Services.TrainingPlan
{
    public class TrainingPlanService : ITrainingPlanService
    {
        private readonly WorkoutAppContext _context;

        public TrainingPlanService(WorkoutAppContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<List<TrainingPlanViewModel>>> GetAllAsync(int skip = 0, int take = 50)
        {
            var trainingPlan = await _context.TrainingPlan.Skip(skip).Take(take).ToListAsync();
            var model = trainingPlan.Select(TrainingPlanViewModel.FromEntity).ToList();
            return ResultViewModel<List<TrainingPlanViewModel>>.Success(model);
        }

        public async Task<ResultViewModel<TrainingPlanViewModel>> GetByIdAsync(Guid id)
        {
            var trainingPlan = await _context.TrainingPlan.AsNoTracking().SingleOrDefaultAsync(e => e.Id == id);
            if (trainingPlan is null)
                return ResultViewModel<TrainingPlanViewModel>.Error("Treino não existe");
            
            var model = TrainingPlanViewModel.FromEntity(trainingPlan);
            
            return ResultViewModel<TrainingPlanViewModel>.Success(model);
        }
        public async Task<ResultViewModel<Guid>> AddAsync(CreateTrainingPlanInputModel model)
        {
            var trainingPlan = model.ToEntity();
            await _context.TrainingPlan.AddAsync(trainingPlan);
            await _context.SaveChangesAsync();
            return ResultViewModel<Guid>.Success(trainingPlan.Id);
        }
        public async Task<ResultViewModel> Update(Guid id, UpdateTrainingPlanInputModel model)
        {
            var trainingPlan = await _context.TrainingPlan.SingleOrDefaultAsync(t => t.Id == id);
            if (trainingPlan is null)
                return ResultViewModel<TrainingPlanViewModel>.Error("Treino não existe");

            trainingPlan.Update(model.Title, model.Description, model.Author, 
                                model.ImageLink, model.Length, model.PerWeek, 
                                model.PerSession, model.Category, model.LocationDifficulty);
            
            _context.TrainingPlan.Update(trainingPlan);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }

        public async Task<ResultViewModel> Delete(Guid id)
        {
            var trainingPlan = await _context.TrainingPlan.SingleOrDefaultAsync(e => e.Id == id);
            if (trainingPlan is null)
                return ResultViewModel<TrainingPlanViewModel>.Error("Exercício não existe");

            trainingPlan.SetAsDeleted();
            _context.TrainingPlan.Update(trainingPlan);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
