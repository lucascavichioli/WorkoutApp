using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WorkoutApp.Core.Entities
{
    public class TrainingPlanTraining : BaseEntity
    {
        public TrainingPlanTraining(Guid trainingPlanFK, Guid trainingFK, int order, int dayOfWeek)
            : base()
        {
            TrainingPlanFK = trainingPlanFK;
            TrainingFK = trainingFK;
            Order = order;
            DayOfWeek = dayOfWeek;
        }
        
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

        public void Update (Guid trainingPlanFK, Guid trainingFK, int order, int dayOfWeek)
        {
            TrainingPlanFK = trainingPlanFK;
            TrainingFK = trainingFK;
            Order = order;
            DayOfWeek = dayOfWeek;
        }

    }
}
