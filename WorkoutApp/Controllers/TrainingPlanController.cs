using Microsoft.AspNetCore.Mvc;
using WorkoutApp.Application.Services.TrainingPlan;
using WorkoutApp.Application.Models.InputViewModels.TrainingPlanInputModels;

namespace WorkoutApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainingPlanController : ControllerBase
    {
        private readonly ITrainingPlanService _trainingPlanService;
        public TrainingPlanController(ITrainingPlanService trainingPlanService)
        {
            _trainingPlanService = trainingPlanService;
        }

        /// <summary>
        /// Adiciona um plano de treino ao banco de dados
        /// </summary>
        /// <param name="CreateTrainingPlanDTO">Objeto com os campos necessários para criação de um plano de treino</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddTrainingPlan(CreateTrainingPlanInputModel model) 
        {
            var result = await _trainingPlanService.AddAsync(model);

            return CreatedAtAction(nameof(GetTrainingPlanById), new { id = result.Data }, result);
        }
        
        [HttpGet]
        [ResponseCache(CacheProfileName = "DefaultCache")]
        public async Task<IActionResult> GetTrainingPlan(int skip = 0, int take = 50) 
        {
            var trainingPlan = await _trainingPlanService.GetAllAsync(skip, take);
            if (!trainingPlan.IsSuccess)
                return NotFound();

            return Ok(trainingPlan);
        }

        
        [HttpGet("{id}")]
        [ResponseCache(CacheProfileName = "DefaultCache")]
        public async Task<IActionResult> GetTrainingPlanById(Guid id)
        {
            var trainingPlan = await _trainingPlanService.GetByIdAsync(id);
            if (!trainingPlan.IsSuccess)
                return NotFound(trainingPlan.Message);

            return Ok(trainingPlan);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrainingPlan(Guid id, UpdateTrainingPlanInputModel model)
        {
            var trainingPlan = await _trainingPlanService.GetByIdAsync(id);
            if (!trainingPlan.IsSuccess)
                return NotFound(trainingPlan.Message);

            var result = await _trainingPlanService.Update(id, model);
            return Ok(result.Message);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteTrainingPlan(Guid id) 
        {
            var trainingPlan = await _trainingPlanService.GetByIdAsync(id);
            if (!trainingPlan.IsSuccess)
                return NotFound();

            await _trainingPlanService.Delete(id);
            return NoContent();
        }
       

    }
}
