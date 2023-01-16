using AutoMapper;
using WorkoutApp.Data.Dtos;
using WorkoutApp.Models;

namespace WorkoutApp.Profiles;

public class TrainingPlanTrainingProfile : Profile
{
    public TrainingPlanTrainingProfile()
    {
        CreateMap<CreateTrainingPlanTrainingDTO, TrainingPlanTraining>();
        CreateMap<UpdateTrainingPlanTrainingDTO, TrainingPlanTraining>();
        CreateMap<TrainingPlanTraining, UpdateTrainingPlanTrainingDTO>();
        CreateMap<TrainingPlanTraining, ReadTrainingPlanTrainingDTO>();
    }
}
