using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WorkoutApp.Data;
using WorkoutApp.Data.Dtos;
using WorkoutApp.Models;

namespace WorkoutApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private WorkoutAppContext _context;
        private IMapper _mapper;

        public TrainingController(WorkoutAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddTraining([FromBody] CreateTrainingDTO trainingDTO)
        {
            Training training = _mapper.Map<Training>(trainingDTO);
            _context.Training.Add(training);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetTrainingById), new { id = training.Id }, training);
        }

        [HttpGet]
        public IEnumerable<ReadTrainingDTO> GetTraining([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadTrainingDTO>>(_context.Training.Skip(skip).Take(take));
        }

        [HttpGet("{id}")]
        public IActionResult GetTrainingById(Guid id)
        {
            var training = _context.Training.FirstOrDefault(training => training.Id == id);
            if (training == null) return NotFound();

            var trainingDTO = _mapper.Map<ReadTrainingDTO>(training);

            return Ok(trainingDTO);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTraining(Guid id, [FromBody] UpdateTrainingDTO trainingDTO)
        {
            var training = _context.Training.FirstOrDefault(training => training.Id == id);
            if (training == null) return NotFound();
            _mapper.Map(trainingDTO, training);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PartialUpdateTraining(Guid id, JsonPatchDocument<UpdateTrainingDTO> patch)
        {
            var training = _context.Training.FirstOrDefault(training => training.Id == id);
            if (training == null) return NotFound();

            var trainingForUpdate = _mapper.Map<UpdateTrainingDTO>(training);
            patch.ApplyTo(trainingForUpdate, ModelState);

            if (!TryValidateModel(trainingForUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(trainingForUpdate, training);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteTraining(Guid id)
        {
            var training = _context.Training.FirstOrDefault(training => training.Id == id);
            if (training == null) return NotFound();

            _context.Remove(training);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
