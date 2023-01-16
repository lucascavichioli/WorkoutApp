using WorkoutApp.Data.Dtos;
using WorkoutApp.Models;
using AutoMapper;

namespace WorkoutApp.Profiles
{
    public class TrainingExerciseProfile : Profile
    {
        public TrainingExerciseProfile()
        {
            CreateMap<CreateTrainingExercisesDTO, TrainingExercises>();
            CreateMap<UpdateTrainingExercisesDTO, TrainingExercises>();
            CreateMap<TrainingExercises, UpdateTrainingExercisesDTO>();
            CreateMap<TrainingExercises, ReadTrainingExercisesDTO>();
        }
    }
}
