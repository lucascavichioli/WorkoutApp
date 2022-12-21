using AutoMapper;
using WorkoutApp.Data.Dtos;
using WorkoutApp.Models;

namespace WorkoutApp.Profiles
{
    public class ExercisesProfile : Profile
    {
        public ExercisesProfile()
        {
            CreateMap<CreateExerciseDTO, Exercises>();
            CreateMap<UpdateExerciseDTO, Exercises>();
            CreateMap<Exercises, UpdateExerciseDTO>();
            CreateMap<Exercises, ReadExerciseDTO>();
        }
    }
}
