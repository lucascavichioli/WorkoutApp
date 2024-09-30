using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WorkoutApp.Core.Entities
{
    public class TrainingPlan : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int Author { get; set; } //reference

        [StringLength(255)]
        public string? ImageLink { get; set; }

        public short Length { get; set; } //quantas semanas

        public short PerWeek { get; set; } //quantos dias por semana

        public short PerSession { get; set; } //quantos minutos por sessão de treino

        public int Category { get; set; } // Corrida / Cardio / HIIT reference

        [StringLength(50)]
        public string? LocationDifficulty { get; set; } // reference

        public int Comments { get; set; } 
        public int Likes { get; set; }

        [JsonIgnore]
        public virtual List<TrainingPlanTraining> TrainingPlanTraining { get; set; }

        public TrainingPlan(string title, string description, int author, 
                            string? imageLink, short length, short perWeek, 
                            short perSession, int category, string? locationDifficulty, 
                            int comments, int likes) 
            : base()
        {
            Title = title;
            Description = description;
            Author = author;
            ImageLink = imageLink;
            Length = length;
            PerWeek = perWeek;
            PerSession = perSession;
            Category = category;
            LocationDifficulty = locationDifficulty;
            Comments = comments;
            Likes = likes;
        }

        public void Update(string title, string description, int author,
                    string? imageLink, short length, short perWeek,
                    short perSession, int category, string? locationDifficulty)
        {
            Title = title;
            Description = description;
            Author = author;
            ImageLink = imageLink;
            Length = length;
            PerWeek = perWeek;
            PerSession = perSession;
            Category = category;
            LocationDifficulty = locationDifficulty;
        }
    }
}
