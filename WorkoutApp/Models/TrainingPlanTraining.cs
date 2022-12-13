using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutApp.Models
{
    public class TrainingPlanTraining
    {
        public virtual TrainingPlan TrainingPlan { get; set; }
        [Required]
        public Guid TrainingPlanFK { get; set; }

        public virtual Training Training { get; set; }
        [Required]
        public Guid TrainingFK { get; set; }
        

        public int Order { get; set; }

        public int DayOfWeek { 
                                get => DayOfWeek; 
                                set { 
                                        if (value >= 0 && value < 7) 
                                            DayOfWeek = value; 
                                    } 
                             }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Guid TraceId { get; set; }
    }
}
