using System.Reflection;
using DailyTaskManager.Application.Interfaces;
using DailyTaskManager.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DailyTaskManager.Application;

public static class ApplicationServicesConfigurations
{
  public static IServiceCollection AddApplicationServices(this IServiceCollection services)
  {
    services.AddAutoMapper(Assembly.GetExecutingAssembly());
    services.AddScoped<ISprintService, SprintService>();
    return services;
  }
}