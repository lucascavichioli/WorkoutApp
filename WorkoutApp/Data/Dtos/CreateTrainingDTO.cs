using System.ComponentModel.DataAnnotations;
using WorkoutApp.Models;

namespace WorkoutApp.Data.Dtos
{
    public class CreateTrainingDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public short DurationMinutes { get; set; } //minutes

        public int Likes { get; set; }
        public int Comments { get; set; }

    }
}
