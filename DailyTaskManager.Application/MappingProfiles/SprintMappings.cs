using AutoMapper;
using DailyTaskManager.Application.Models;
using DailyTaskManager.Application.Models.Sprint;
using DailyTaskManager.Domain.Entities;

namespace DailyTaskManager.Application.MappingProfiles;

public class SprintMappings : Profile
{
  public SprintMappings()
  {
    CreateMap<SprintDto, Sprint>();
  }
}