using AutoMapper;
using WorkoutApp.Data.Dtos;
using WorkoutApp.Models;

namespace WorkoutApp.Profiles;

public class TrainingPlanProfile : Profile
{
	public TrainingPlanProfile()
	{
		CreateMap<CreateTrainingPlanDTO, TrainingPlan>();
        CreateMap<UpdateTrainingPlanDTO, TrainingPlan>();
        CreateMap<TrainingPlan, UpdateTrainingPlanDTO>();
        CreateMap<TrainingPlan, ReadTrainingPlanDTO>();
    }
}
