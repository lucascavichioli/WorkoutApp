using Microsoft.AspNetCore.Mvc;
using WorkoutApp.Application.Services.Training;
using WorkoutApp.Application.Models.InputViewModels.TrainingInputModels;

namespace WorkoutApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingService _trainingService;

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddTraining(CreateTrainingInputModel trainingInputModel)
        {
            var result = await _trainingService.AddAsync(trainingInputModel);

            return CreatedAtAction(nameof(GetTrainingById), new { id = result.Data }, result);
        }
       
        [HttpGet]
        [ResponseCache(CacheProfileName = "DefaultCache")]
        public async Task<IActionResult> GetTraining(int skip = 0, int take = 50)
        {
            var training = await _trainingService.GetAllAsync(skip, take);
            if (!training.IsSuccess)
                return NotFound();

            return Ok(training);
        }

        [HttpGet("{id}")]
        [ResponseCache(CacheProfileName = "DefaultCache")]
        public async Task<IActionResult> GetTrainingById(Guid id)
        {
            var training = await _trainingService.GetByIdAsync(id);
            if (!training.IsSuccess)
                return NotFound(training.Message);

            return Ok(training);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTraining(Guid id, UpdateTrainingInputModel model)
        {
            var training = await _trainingService.GetByIdAsync(id);
            if (!training.IsSuccess)
                return NotFound(training.Message);

            var result = await _trainingService.Update(id, model);
            return Ok(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraining(Guid id)
        {
            var training = await _trainingService.GetByIdAsync(id);
            if (!training.IsSuccess)
                return NotFound();

            await _trainingService.Delete(id);
            return NoContent();
        }
       
    }
}
