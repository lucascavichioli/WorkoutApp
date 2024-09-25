using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WorkoutApp.Core.Entities
{
    public class TrainingPlanTraining : BaseEntity
    {
        [JsonIgnore]
        public virtual TrainingPlan TrainingPlan { get; set; }
        
        [Required]
        public Guid TrainingPlanFK { get; set; }
        
        [JsonIgnore]
        public virtual Training Training { get; set; }
        [Required]
        public Guid TrainingFK { get; set; }

        [Required]
        public int Order { get; set; }

        public int DayOfWeek { get; set; }
    }
}
