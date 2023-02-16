using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkoutApp.Data;
using WorkoutApp.Data.Dtos;
using WorkoutApp.Models;

namespace WorkoutApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainingPlanTrainingController : ControllerBase
    {
        private WorkoutAppContext _context;
        private IMapper _mapper;

        public TrainingPlanTrainingController(WorkoutAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddTrainingPlanTraining([FromBody] CreateTrainingPlanTrainingDTO trainingPlanTrainingDTO)
        {
            TrainingPlanTraining trainingPlanTraining = _mapper.Map<TrainingPlanTraining>(trainingPlanTrainingDTO);
            _context.TrainingPlanTraining.Add(trainingPlanTraining);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetTrainingPlanTrainingUnique), new { id = trainingPlanTraining.Id }, trainingPlanTraining);
        }

        [ResponseCache(CacheProfileName = "Default86400")]
        [HttpGet]
        public IEnumerable<ReadTrainingPlanTrainingDTO> GetTrainingPlanTraining([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadTrainingPlanTrainingDTO>>(_context.TrainingPlanTraining.Skip(skip).Take(take));
        }

        [ResponseCache(CacheProfileName = "Default86400")]
        [HttpGet("unique/{id}")]
        public IActionResult GetTrainingPlanTrainingUnique(Guid id)
        {
            var trainingPlanTraining = _context.TrainingPlanTraining.FirstOrDefault(trainingPlanTraining => trainingPlanTraining.Id == id);
            if (trainingPlanTraining == null) return NotFound();

            var trainingPlanTrainingDTO = _mapper.Map<List<ReadTrainingPlanTrainingDTO>>(trainingPlanTraining);

            return Ok(trainingPlanTrainingDTO);
        }

        [ResponseCache(CacheProfileName = "Default86400")]
        [HttpGet("{trainingPlanId}")]
        public IActionResult GetTrainingPlanTrainingById(Guid trainingPlanId)
        {
            //var trainingPlanTraining = _context.TrainingPlanTraining.Where(trainingPlanTraining => trainingPlanTraining.TrainingPlanFK == trainingPlanId);

            var trainingPlanTraining = _context.TrainingPlanTraining
                                               .Include(x => x.Training)
                                               .Where(x => x.TrainingPlanFK == trainingPlanId);

            if (trainingPlanTraining == null) return NotFound();

            var trainingPlanTrainingDTO = _mapper.Map<List<ReadTrainingPlanTrainingDTO>>(trainingPlanTraining);

            return Ok(trainingPlanTrainingDTO);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTrainingPlanTraining(Guid id, [FromBody] UpdateTrainingPlanTrainingDTO trainingPlanTrainingDTO)
        {
            var trainingPlanTraining = _context.TrainingPlanTraining.FirstOrDefault(trainingPlanTraining => trainingPlanTraining.Id == id);
            if (trainingPlanTraining == null) return NotFound();
            _mapper.Map(trainingPlanTrainingDTO, trainingPlanTraining);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PartialUpdateTrainingPlanTraining(Guid id, JsonPatchDocument<UpdateTrainingPlanTrainingDTO> patch)
        {
            var trainingPlanTraining = _context.TrainingPlanTraining.FirstOrDefault(trainingPlanTraining => trainingPlanTraining.Id == id);
            if (trainingPlanTraining == null) return NotFound();

            var trainingPlanTrainingForUpdate = _mapper.Map<UpdateTrainingPlanTrainingDTO>(trainingPlanTraining);
            patch.ApplyTo(trainingPlanTrainingForUpdate, ModelState);

            if (!TryValidateModel(trainingPlanTrainingForUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(trainingPlanTrainingForUpdate, trainingPlanTraining);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTrainingPlanTraining(Guid id)
        {
            var trainingPlanTraining = _context.TrainingPlanTraining.FirstOrDefault(trainingPlanTraining => trainingPlanTraining.Id == id);
            if (trainingPlanTraining == null) return NotFound();

            _context.Remove(trainingPlanTraining);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
