using DailyTaskManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DailyTaskManager.Infrastructure.EntityConfigurations;

public class SprintConfigs : IEntityTypeConfiguration<Sprint>
{
  public void Configure(EntityTypeBuilder<Sprint> builder)
  {
    builder
      .HasMany(s => s.SprintTasks)
      .WithOne(s => s.Sprint)
      .IsRequired(false);

    builder.HasQueryFilter(s => s.IsDeleted == false);
  }
}