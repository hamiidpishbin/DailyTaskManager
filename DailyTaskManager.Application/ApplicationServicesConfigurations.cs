using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace DailyTaskManager.Application;

public static class ApplicationServicesConfigurations
{
  public static IServiceCollection AddApplicationServices(this IServiceCollection services)
  {
    return services;
  }
}