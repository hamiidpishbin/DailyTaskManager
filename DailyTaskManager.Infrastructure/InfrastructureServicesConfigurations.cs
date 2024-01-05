using Ardalis.GuardClauses;
using DailyTaskManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DailyTaskManager.Infrastructure;

public static class InfrastructureServicesConfigurations
{
  public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
    IConfiguration configuration)
  {
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    Guard.Against.Null(connectionString, message: "Connection String 'DefaultConnection' Not Found");
    services.AddDbContext<ApplicationDbContext>((options) =>
    {
      options.UseSqlServer(connectionString);
    });

    return services;
  }
}