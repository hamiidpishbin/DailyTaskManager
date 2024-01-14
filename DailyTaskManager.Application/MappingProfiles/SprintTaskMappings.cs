using AutoMapper;
using DailyTaskManager.Application.Models.SprintTask;
using DailyTaskManager.Domain.Entities;

namespace DailyTaskManager.Application.MappingProfiles;

public class SprintTaskMappings : Profile
{
  public SprintTaskMappings()
  {
    CreateMap<BaseSprintTaskDto, SprintTask>();
    CreateMap<SprintTask, SprintTaskDto>();
  }
}