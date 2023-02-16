using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using System.Text.Json.Serialization;

namespace WorkoutApp.Models
{
    public class TrainingPlanTraining
    {

        [Key]
        [Required]
        public Guid Id { get; set; }

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

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Guid TraceId { get; set; }
    }
}
