using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WorkoutApp.Data.Dtos;
using WorkoutApp.Data;
using WorkoutApp.Models;

namespace WorkoutApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private WorkoutAppContext _context;
        private IMapper _mapper;

        public ExercisesController(WorkoutAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddExercise([FromBody] CreateExerciseDTO exerciseDTO)
        {
            Exercises exercise = _mapper.Map<Exercises>(exerciseDTO);
            _context.Exercises.Add(exercise);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetExerciseById), new { id = exercise.Id }, exercise);
        }

        [HttpGet]
        public IEnumerable<ReadExerciseDTO> GetExercise([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadExerciseDTO>>(_context.Exercises.Skip(skip).Take(take));
        }

        [HttpGet("{id}")]
        public IActionResult GetExerciseById(Guid id)
        {
            var exercise = _context.Exercises.FirstOrDefault(exercise => exercise.Id == id);
            if (exercise == null) return NotFound();

            var exerciceDTO = _mapper.Map<ReadExerciseDTO>(exercise);

            return Ok(exerciceDTO);
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
