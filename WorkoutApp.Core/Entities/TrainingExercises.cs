using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WorkoutApp.Core.Entities
{
    public class TrainingExercises : BaseEntity
    {
        [JsonIgnore]
        public virtual Training Training { get; set; }
        [Required]
        public Guid TrainingFK { get; set; }

        [JsonIgnore]
        public virtual Exercises Exercises { get; set; }
        [Required]
        public Guid ExercisesFK { get; set; }

        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public int DurationMinutes { get; set; } // minutes
        public int Sets { get; set; }
        public string Reps { get; set; } //refatorar para deixar dinamico
        public int RestSeconds { get; set; } //descanso em segundos
        public int Likes { get; set; }
        public int Comments { get; set; }

        public int Order { get; set; }

        public TrainingExercises(Guid trainingFK, Guid exercisesFK, string title, 
                                 string description, int durationMinutes, int sets, 
                                 string reps, int restSeconds, int likes, 
                                 int comments, int order)
            : base()
        {
            TrainingFK = trainingFK;
            ExercisesFK = exercisesFK;
            Title = title;
            Description = description;
            DurationMinutes = durationMinutes;
            Sets = sets;
            Reps = reps;
            RestSeconds = restSeconds;
            Likes = likes;
            Comments = comments;
            Order = order;
        }

        public void Update(Guid trainingFK, Guid exercisesFK, string title,
                                 string description, int durationMinutes, int sets,
                                 string reps, int restSeconds, int order)
        {
            TrainingFK = trainingFK;
            ExercisesFK = exercisesFK;
            Title = title;
            Description = description;
            DurationMinutes = durationMinutes;
            Sets = sets;
            Reps = reps;
            RestSeconds = restSeconds;
            Order = order;
        }

    }
}
