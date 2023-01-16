using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
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
            return CreatedAtAction(nameof(GetTrainingPlanTrainingById), new { trainingPlanId = trainingPlanTraining.TrainingPlanFK }, trainingPlanTraining);
        }

        [HttpGet]
        public IEnumerable<ReadTrainingPlanTrainingDTO> GetTrainingPlanTraining([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadTrainingPlanTrainingDTO>>(_context.TrainingPlanTraining.Skip(skip).Take(take));
        }

        [HttpGet("{trainingPlanId}")]
        public IActionResult GetTrainingPlanTrainingById(Guid trainingPlanId)
        {
            var trainingPlanTraining = _context.TrainingPlanTraining.FirstOrDefault(trainingPlanTraining => trainingPlanTraining.TrainingPlanFK == trainingPlanId);
            if (trainingPlanTraining == null) return NotFound();

            var trainingPlanTrainingDTO = _mapper.Map<ReadTrainingPlanTrainingDTO>(trainingPlanTraining);

            return Ok(trainingPlanTrainingDTO);
        }

        [HttpPut("{trainingPlanId, trainingId}")]
        public IActionResult UpdateTrainingPlanTraining(Guid trainingPlanId, Guid trainingId, [FromBody] UpdateTrainingPlanTrainingDTO trainingPlanTrainingDTO)
        {
            var trainingPlanTraining = _context.TrainingPlanTraining.FirstOrDefault(trainingPlanTraining => trainingPlanTraining.TrainingPlanFK == trainingPlanId && trainingPlanTraining.TrainingFK == trainingId);
            if (trainingPlanTraining == null) return NotFound();
            _mapper.Map(trainingPlanTrainingDTO, trainingPlanTraining);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{trainingPlanId, trainingId}")]
        public IActionResult PartialUpdateTrainingPlanTraining(Guid trainingPlanId, Guid trainingId, JsonPatchDocument<UpdateTrainingPlanTrainingDTO> patch)
        {
            var trainingPlanTraining = _context.TrainingPlanTraining.FirstOrDefault(trainingPlanTraining => trainingPlanTraining.TrainingPlanFK == trainingPlanId && trainingPlanTraining.TrainingFK == trainingId);
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

        [HttpDelete("{trainingPlanId, trainingId}")]

        public IActionResult DeleteTrainingPlanTraining(Guid trainingPlanId, Guid trainingId)
        {
            var trainingPlanTraining = _context.TrainingPlanTraining.FirstOrDefault(trainingPlanTraining => trainingPlanTraining.TrainingPlanFK == trainingPlanId && trainingPlanTraining.TrainingFK == trainingId);
            if (trainingPlanTraining == null) return NotFound();

            _context.Remove(trainingPlanTraining);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
