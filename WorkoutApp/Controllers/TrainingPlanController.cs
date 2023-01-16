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
    public class TrainingPlanController : ControllerBase
    {
        private WorkoutAppContext _context;
        private IMapper _mapper;

        public TrainingPlanController(WorkoutAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Adiciona um plano de treino ao banco de dados
        /// </summary>
        /// <param name="CreateTrainingPlanDTO">Objeto com os campos necessários para criação de um filme</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddTrainingPlan([FromBody] CreateTrainingPlanDTO trainingPlanDTO) 
        {
            TrainingPlan trainingPlan = _mapper.Map<TrainingPlan>(trainingPlanDTO);
            _context.TrainingPlan.Add(trainingPlan);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetTrainingPlanById), new { id = trainingPlan.Id }, trainingPlan);
        }

        [HttpGet]
        public IEnumerable<ReadTrainingPlanDTO> GetTrainingPlan([FromQuery] int skip = 0, [FromQuery] int take = 50) 
        {
            return _mapper.Map<List<ReadTrainingPlanDTO>>(_context.TrainingPlan.Skip(skip).Take(take));
        }

        [HttpGet("{id}")]
        public IActionResult GetTrainingPlanById(Guid id)
        {
            var plan = _context.TrainingPlan.FirstOrDefault(plan => plan.Id == id);
            if (plan == null) return NotFound();

            var trainingPlanDTO = _mapper.Map<ReadTrainingPlanDTO>(plan);

            return Ok(trainingPlanDTO);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTrainingPlan(Guid id, [FromBody] UpdateTrainingPlanDTO trainingPlanDTO)
        {
            var trainingPlan = _context.TrainingPlan.FirstOrDefault(trainingPlan => trainingPlan.Id == id);
            if(trainingPlan == null) return NotFound();
            _mapper.Map(trainingPlanDTO, trainingPlan); 
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PartialUpdateTrainingPlan(Guid id, JsonPatchDocument<UpdateTrainingPlanDTO> patch)
        {
            var trainingPlan = _context.TrainingPlan.FirstOrDefault(trainingPlan => trainingPlan.Id == id);
            if (trainingPlan == null) return NotFound();

            var trainingForUpdate = _mapper.Map<UpdateTrainingPlanDTO>(trainingPlan);
            patch.ApplyTo(trainingForUpdate, ModelState);

            if (!TryValidateModel(trainingForUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(trainingForUpdate, trainingPlan);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteTrainingPlan(Guid id) 
        {
            var trainingPlan = _context.TrainingPlan.FirstOrDefault(trainingPlan => trainingPlan.Id == id);
            if (trainingPlan == null) return NotFound();

            _context.Remove(trainingPlan);
            _context.SaveChanges();
            return NoContent();
        }


    }
}
