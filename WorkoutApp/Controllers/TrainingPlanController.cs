using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
using WorkoutApp.Models;

namespace WorkoutApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainingPlanController : ControllerBase
    {
        private static List<TrainingPlan> plans = new List<TrainingPlan>();

        [HttpPost]
        public IActionResult AddTrainingPlan([FromBody] TrainingPlan plan) 
        {
            plan.Id = Guid.NewGuid();
            plans.Add(plan);
            return CreatedAtAction(nameof(GetTrainingPlanById), new { id = plan.Id}, plan);
        }

        [HttpGet]
        public IEnumerable<TrainingPlan> GetTrainingPlan([FromQuery] int skip = 0, [FromQuery] int take = 50) 
        {
            return plans.Skip(skip).Take(take);
        }

        [HttpGet("{id}")]
        public IActionResult GetTrainingPlanById(Guid id)
        {
            var plan = plans.FirstOrDefault(plan => plan.Id == id);
            if (plan == null) return NotFound();

            return Ok(plan);
        }

    }
}
