using AutoMapper;
using DailyTaskManager.Application.Models.Identity;
using DailyTaskManager.Infrastructure.Models;

namespace DailyTaskManager.Infrastructure;

public class MappingProfiles : Profile
{
  public MappingProfiles()
  {
    CreateMap<AppUser, AppUserDto>();
  }
}