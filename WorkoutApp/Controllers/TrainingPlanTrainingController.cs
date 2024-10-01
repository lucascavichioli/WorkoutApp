using Microsoft.AspNetCore.Mvc;
using WorkoutApp.Application.Models.InputViewModels.TrainingPlanTrainingInputModels;
using WorkoutApp.Application.Services.TrainingPlanTraining;

namespace WorkoutApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainingPlanTrainingController : ControllerBase
    {
        private readonly ITrainingPlanTrainingService _trainingPlanTrainingService;

        public TrainingPlanTrainingController(ITrainingPlanTrainingService trainingPlanTrainingService)
        {
            _trainingPlanTrainingService = trainingPlanTrainingService;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddTrainingPlanTraining([FromBody] CreateTrainingPlanTrainingInputModel model)
        {
            var result = await _trainingPlanTrainingService.AddAsync(model);

            return CreatedAtAction(nameof(GetTrainingPlanTrainingById), new { id = result.Data }, result);
        }

        [HttpGet]
        [ResponseCache(CacheProfileName = "DefaultCache")]
        public async Task<IActionResult> GetTrainingPlanTraining([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            var trainingPlanTraining = await _trainingPlanTrainingService.GetAllAsync(skip, take);
            if (!trainingPlanTraining.IsSuccess)
                return NotFound();

            return Ok(trainingPlanTraining);
        }

        
        [HttpGet("unique/{id}")]
        [ResponseCache(CacheProfileName = "DefaultCache")]
        public async Task<IActionResult> GetTrainingPlanTrainingById(Guid id)
        {
            var trainingPlanTraining = await _trainingPlanTrainingService.GetByIdAsync(id);
            if (!trainingPlanTraining.IsSuccess)
                return NotFound(trainingPlanTraining.Message);

            return Ok(trainingPlanTraining);
        }

        [HttpGet("{id}")]
        [ResponseCache(CacheProfileName = "DefaultCache")]
        public async Task<IActionResult> GetByTrainingPlanId(Guid id)
        {
            var trainingPlanTraining = await _trainingPlanTrainingService.GetByTrainingPlanIdAsync(id);
            if (!trainingPlanTraining.IsSuccess)
                return NotFound();

            return Ok(trainingPlanTraining);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrainingPlanTraining(Guid id, [FromBody] UpdateTrainingPlanTrainingInputModel model)
        {
            var trainingPlanTraining = await _trainingPlanTrainingService.GetByIdAsync(id);
            if (!trainingPlanTraining.IsSuccess)
                return NotFound(trainingPlanTraining.Message);

            var result = await _trainingPlanTrainingService.Update(id, model);
            return Ok(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainingPlanTraining(Guid id)
        {
            var trainingPlanTraining = await _trainingPlanTrainingService.GetByIdAsync(id);
            if (!trainingPlanTraining.IsSuccess)
                return NotFound();

            await _trainingPlanTrainingService.Delete(id);
            return NoContent();
        }

    }
}
