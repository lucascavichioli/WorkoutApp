using WorkoutApp.Core.Entities;

namespace WorkoutApp.Application.Models.ViewViewModels.TrainingPlanViewModels
{
    public class TrainingPlanViewModel
    {
        public TrainingPlanViewModel(string title, string description, int author, 
                                     string? imageLink, short length, short perWeek, 
                                     short perSession, int category, string? locationDifficulty, 
                                     int comments, int likes)
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

        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public int Author { get; set; } //reference

        public string? ImageLink { get; set; }

        public short Length { get; set; } //quantas semanas

        public short PerWeek { get; set; } //quantos dias por semana

        public short PerSession { get; set; } //quantos minutos por sessão de treino

        public int Category { get; set; } // Corrida / Cardio / HIIT reference

        public string? LocationDifficulty { get; set; } // reference

        public int Comments { get; set; }
        public int Likes { get; set; }


        public static TrainingPlanViewModel FromEntity(TrainingPlan trainingPlan)
            => new(trainingPlan.Title, trainingPlan.Description,
                   trainingPlan.Author, trainingPlan.ImageLink,
                   trainingPlan.Length, trainingPlan.PerWeek,
                   trainingPlan.PerSession, trainingPlan.Category,
                   trainingPlan.LocationDifficulty, trainingPlan.Comments,
                   trainingPlan.Likes);
    }
}
