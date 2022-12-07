using Microsoft.AspNetCore.Mvc;
using WorkoutApp.Models;

namespace WorkoutApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainingPlanController : ControllerBase
    {
        private static List<TrainingPlan> plans = new List<TrainingPlan>();

        [HttpPost]
        public void AddTrainingPlan([FromBody] TrainingPlan plan) 
        {
            plans.Add(plan);
            Console.WriteLine(plan.Author);
        }

        [HttpGet]
        public IEnumerable<TrainingPlan> GetTrainingPlan() 
        {
            return plans;
        }

    }
}
