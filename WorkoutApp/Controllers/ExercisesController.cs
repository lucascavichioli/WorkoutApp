using Microsoft.AspNetCore.Mvc;
using WorkoutApp.Application.Models.InputViewModels.ExercisesInputModels;
using WorkoutApp.Application.Services.Exercises;

namespace WorkoutApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;
        public ExercisesController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddExercise(CreateExercisesInputModel exerciseInputModel)
        {
            var result = await _exerciseService.AddAsync(exerciseInputModel);

            return CreatedAtAction(nameof(GetExerciseById), new { id = result.Data }, result);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetExercise([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            var exercises = await _exerciseService.GetAllAsync(skip, take);
            if(!exercises.IsSuccess)
                return NotFound();

            return Ok(exercises);
        }

        [HttpGet("{id}")]
        [ResponseCache(CacheProfileName = "DefaultCache")]
        public async Task<IActionResult> GetExerciseById(Guid id)
        {
            var exercise = await _exerciseService.GetByIdAsync(id);
            if(!exercise.IsSuccess)
                return NotFound(exercise.Message);

            return Ok(exercise);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExercise(Guid id, UpdateExercisesInputModel model)
        {
            var exercise = await _exerciseService.GetByIdAsync(id);
            if(!exercise.IsSuccess)
                return NotFound(exercise.Message);

            var result = await _exerciseService.Update(id, model);
            return Ok(result.Message);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteExercise(Guid id)
        {
            var exercise = await _exerciseService.GetByIdAsync(id);
            if (!exercise.IsSuccess)
                return NotFound();

            await _exerciseService.Delete(id);
            return NoContent();
        }
        
    }
}
