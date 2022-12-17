using AutoMapper;
using WorkoutApp.Data.Dtos;
using WorkoutApp.Models;

namespace WorkoutApp.Profiles;
public class TrainginProfile : Profile
{
    public TrainginProfile()
    {
        CreateMap<CreateTrainingDTO, Training>();
        CreateMap<UpdateTrainingDTO, Training>();
        CreateMap<Training, UpdateTrainingDTO>();
        CreateMap<Training, ReadTrainingDTO>();
    }

}
