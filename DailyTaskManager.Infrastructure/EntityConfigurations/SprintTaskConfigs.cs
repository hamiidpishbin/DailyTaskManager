using DailyTaskManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DailyTaskManager.Infrastructure.EntityConfigurations;

public class SprintTaskConfigs : IEntityTypeConfiguration<SprintTask>
{
  public void Configure(EntityTypeBuilder<SprintTask> builder)
  {
    builder.HasQueryFilter(s => s.IsDeleted == false);
  }
}