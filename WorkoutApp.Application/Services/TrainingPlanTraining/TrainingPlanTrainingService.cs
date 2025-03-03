using Microsoft.EntityFrameworkCore;
using WorkoutApp.Application.Models;
using WorkoutApp.Application.Models.InputViewModels.TrainingPlanTrainingInputModels;
using WorkoutApp.Application.Models.ViewViewModels.TrainingPlanTrainingViewModels;
using WorkoutApp.Application.Models.ViewViewModels.TrainingPlanViewModels;
using WorkoutApp.Infrastructure.Persistence;
using System.Collections.Generic;
using WorkoutApp.Core.Entities;

namespace WorkoutApp.Application.Services.TrainingPlanTraining
{
    public class TrainingPlanTrainingService : ITrainingPlanTrainingService
    {
        private readonly WorkoutAppContext _context;

        public TrainingPlanTrainingService(WorkoutAppContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<List<TrainingPlanTrainingViewModel>>> GetAllAsync(int skip = 0, int take = 50)
        {
            var trainingPlanTraining = await _context.TrainingPlanTraining.Skip(skip).Take(take).ToListAsync();
            var model = trainingPlanTraining.Select(TrainingPlanTrainingViewModel.FromEntity).ToList();
            return ResultViewModel<List<TrainingPlanTrainingViewModel>>.Success(model);
        }

        public async Task<ResultViewModel<TrainingPlanTrainingViewModel>> GetByIdAsync(Guid id)
        {
            var trainingPlanTraining = await _context.TrainingPlanTraining.AsNoTracking().SingleOrDefaultAsync(e => e.Id == id);
            if (trainingPlanTraining is null)
                return ResultViewModel<TrainingPlanTrainingViewModel>.Error("Vínculo do plano de treino com o treino não existe");
            
            var model = TrainingPlanTrainingViewModel.FromEntity(trainingPlanTraining);
            
            return ResultViewModel<TrainingPlanTrainingViewModel>.Success(model);
        }

        public async Task<ResultViewModel<List<TrainingPlanTrainingViewModel>>> GetByTrainingPlanIdAsync(Guid id)
        {
            var trainingPlanTraining = await _context.TrainingPlanTraining
                                        .Include(x => x.Training)
                                        .Where(x => x.TrainingPlanFK == id)
                                        .Select(x => TrainingPlanTrainingViewModel.FromEntity(x))
                                        .ToListAsync();

            if (trainingPlanTraining is null)
                return ResultViewModel<List<TrainingPlanTrainingViewModel>>.Error("Vínculo do plano de treino com o treino não existe");

            return ResultViewModel<List<TrainingPlanTrainingViewModel>>.Success(trainingPlanTraining);
        }

        public async Task<ResultViewModel<Guid>> AddAsync(CreateTrainingPlanTrainingInputModel model)
        {
            var trainingPlanTraining = model.ToEntity();
            await _context.TrainingPlanTraining.AddAsync(trainingPlanTraining);
            await _context.SaveChangesAsync();
            return ResultViewModel<Guid>.Success(trainingPlanTraining.Id);
        }
        public async Task<ResultViewModel> Update(Guid id, UpdateTrainingPlanTrainingInputModel model)
        {
            var trainingPlanTraining = await _context.TrainingPlanTraining.SingleOrDefaultAsync(t => t.Id == id);
            if (trainingPlanTraining is null)
                return ResultViewModel<TrainingPlanViewModel>.Error("Vínculo do plano de treino com o treino não existe");

            trainingPlanTraining.Update(model.TrainingPlanFK, model.TrainingFK, model.Order, model.DayOfWeek);
            
            _context.TrainingPlanTraining.Update(trainingPlanTraining);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }

        public async Task<ResultViewModel> Delete(Guid id)
        {
            var trainingPlanTraining = await _context.TrainingPlanTraining.SingleOrDefaultAsync(e => e.Id == id);
            if (trainingPlanTraining is null)
                return ResultViewModel<TrainingPlanTrainingViewModel>.Error("Vínculo do plano de treino com o treino não existe");

            trainingPlanTraining.SetAsDeleted();
            _context.TrainingPlanTraining.Update(trainingPlanTraining);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
