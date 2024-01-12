using DailyTaskManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DailyTaskManager.Infrastructure.EntityConfigurations;

public class SprintConfigs : IEntityTypeConfiguration<Sprint>
{
  public void Configure(EntityTypeBuilder<Sprint> builder)
  {
    builder.HasQueryFilter(s => s.IsDeleted == false);
  }
}