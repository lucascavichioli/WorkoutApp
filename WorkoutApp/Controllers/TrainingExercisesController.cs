using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WorkoutApp.Data.Dtos;
using WorkoutApp.Data;
using WorkoutApp.Models;
using Microsoft.EntityFrameworkCore;

namespace WorkoutApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TrainingExercisesController : ControllerBase
    {
        private WorkoutAppContext _context;
        private IMapper _mapper;

        public TrainingExercisesController(WorkoutAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddTrainingExercise([FromBody] CreateTrainingExercisesDTO TrainingExerciseDTO)
        {
            TrainingExercises trainingExercise = _mapper.Map<TrainingExercises>(TrainingExerciseDTO);
            _context.TrainingExercises.Add(trainingExercise);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetTrainingExerciseById), new { id = trainingExercise.Id }, trainingExercise);
        }

        [HttpGet]
        public IEnumerable<ReadTrainingExercisesDTO> GetTrainingExercise([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadTrainingExercisesDTO>>(_context.TrainingExercises.Skip(skip).Take(take));
        }

        [ResponseCache(CacheProfileName = "Default86400")]
        [HttpGet("{id}")]
        public IActionResult GetTrainingExerciseById(Guid id)
        {
            var trainingExercise = _context.TrainingExercises.FirstOrDefault(trainingExercise => trainingExercise.Id == id);
            if (trainingExercise == null) {
                return GetTrainingExerciseByTrainingId(id);
            } 

            var trainingExerciseDTO = _mapper.Map<ReadTrainingExercisesDTO>(trainingExercise);

            return Ok(trainingExerciseDTO);
        }

        [HttpGet("{trainingId}")]
        private IActionResult GetTrainingExerciseByTrainingId(Guid trinaingId)
        {
            var trainingExercise = _context.TrainingExercises.Where(trainingExercise => trainingExercise.TrainingFK == trinaingId);
            if (trainingExercise == null) return NotFound();

            var trainingExerciseDTO = _mapper.Map<List<ReadTrainingExercisesDTO>>(trainingExercise);

            return Ok(trainingExerciseDTO);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTrainingExercise(Guid id, [FromBody] UpdateTrainingExercisesDTO trainingExerciseDTO)
        {
            var trainingExercise = _context.TrainingExercises.FirstOrDefault(trainingExercise => trainingExercise.Id == id);
            if (trainingExercise == null) return NotFound();
            _mapper.Map(trainingExerciseDTO, trainingExercise);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PartialUpdateTrainingExercise(Guid id, JsonPatchDocument<UpdateTrainingExercisesDTO> patch)
        {
            var trainingExercise = _context.TrainingExercises.FirstOrDefault(trainingExercise => trainingExercise.Id == id);
            if (trainingExercise == null) return NotFound();

            var trainingExerciseForUpdate = _mapper.Map<UpdateTrainingExercisesDTO>(trainingExercise);
            patch.ApplyTo(trainingExerciseForUpdate, ModelState);

            if (!TryValidateModel(trainingExerciseForUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(trainingExerciseForUpdate, trainingExercise);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteTrainingExercise(Guid id)
        {
            var trainingExercise = _context.TrainingExercises.FirstOrDefault(trainingExercise => trainingExercise.Id == id);
            if (trainingExercise == null) return NotFound();

            _context.Remove(trainingExercise);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
