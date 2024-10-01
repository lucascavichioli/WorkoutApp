using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WorkoutApp.Application.Services.TrainingExercises;
using WorkoutApp.Application.Models.InputViewModels.TrainingExerciseInputModels;

namespace WorkoutApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TrainingExercisesController : ControllerBase
    {
        private readonly ITrainingExerciseService _trainingExerciseService;
        public TrainingExercisesController(ITrainingExerciseService trainingExerciseService)
        {
            _trainingExerciseService = trainingExerciseService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddTrainingExercise(CreateTrainingExerciseInputModel model)
        {
            var result = await _trainingExerciseService.AddAsync(model);

            return CreatedAtAction(nameof(GetTrainingExerciseById), new { id = result.Data }, result);
        }
       
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetTrainingExercise(int skip = 0, int take = 50)
        {
            var trainingExercise = await _trainingExerciseService.GetAllAsync(skip, take);
            if (!trainingExercise.IsSuccess)
                return NotFound();

            return Ok(trainingExercise);
        }

        /// <summary>
        /// Retorna vínculo do treino e exercício por id
        /// </summary>
        [ResponseCache(CacheProfileName = "DefaultCache")]
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetTrainingExerciseById(Guid id)
        {
            var trainingExercise = await _trainingExerciseService.GetByIdAsync(id);
            if (!trainingExercise.IsSuccess)
                return NotFound(trainingExercise.Message);

            return Ok(trainingExercise);
        }

        [HttpGet("{trainingId}")]
        [AllowAnonymous]
        private async Task<IActionResult> GetTrainingExerciseByTrainingId(Guid trinaingId)
        {
            var trainingExercise = await _trainingExerciseService.GetByTrainingIdAsync(trinaingId);
            if (!trainingExercise.IsSuccess)
                return NotFound();

            return Ok(trainingExercise);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrainingExercise(Guid id, UpdateTrainingExerciseInputModel model)
        {
            var trainingExercise = await _trainingExerciseService.GetByIdAsync(id);
            if (!trainingExercise.IsSuccess)
                return NotFound(trainingExercise.Message);

            var result = await _trainingExerciseService.Update(id, model);
            return Ok(result.Message);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteTrainingExercise(Guid id)
        {
            var trainingExercise = await _trainingExerciseService.GetByIdAsync(id);
            if (!trainingExercise.IsSuccess)
                return NotFound();

            await _trainingExerciseService.Delete(id);
            return NoContent();
        }
       
    }
}
