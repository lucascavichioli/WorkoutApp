﻿using System.ComponentModel.DataAnnotations;
using WorkoutApp.Models;

namespace WorkoutApp.Data.Dtos
{
    public class CreateExerciseDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int DurationMinutes { get; set; } //minutes

        public int Sets { get; set; }
        public int Reps { get; set; } //refatorar para deixar dinamico
        public string? LinkVideo { get; set; }
        public int RestSeconds { get; set; } //descanso em segundos
    }
}
