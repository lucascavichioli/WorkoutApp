using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WorkoutApp.Data.Dtos;
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
                return NotFound();

            return Ok(exercise);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateExercise(Guid id, [FromBody] UpdateExerciseDTO exerciseDTO)
        {
            var exercise = _context.Exercises.FirstOrDefault(exercise => exercise.Id == id);
            if (exercise == null) return NotFound();
            _mapper.Map(exerciseDTO, exercise);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PartialUpdateExercise(Guid id, JsonPatchDocument<UpdateExerciseDTO> patch)
        {
            var exercise = _context.Exercises.FirstOrDefault(exercise => exercise.Id == id);
            if (exercise == null) return NotFound();

            var exerciseForUpdate = _mapper.Map<UpdateExerciseDTO>(exercise);
            patch.ApplyTo(exerciseForUpdate, ModelState);

            if (!TryValidateModel(exerciseForUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(exerciseForUpdate, exercise);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteExercise(Guid id)
        {
            var exercise = _context.Exercises.FirstOrDefault(exercise => exercise.Id == id);
            if (exercise == null) return NotFound();

            _context.Remove(exercise);
            _context.SaveChanges();
            return NoContent();
        }
        
    }
}
