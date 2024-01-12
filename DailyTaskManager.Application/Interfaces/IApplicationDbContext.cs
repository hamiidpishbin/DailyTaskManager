using DailyTaskManager.Domain.Entities;
using DailyTaskManager.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace DailyTaskManager.Application.Interfaces;

public interface IApplicationDbContext
{
  DbSet<DailyTask> Tasks { get; }
  DbSet<DelayedTask> DelayedTasks { get; }
  DbSet<Sprint> Sprints { get; }
  Task<int> SaveChangesAsync(CancellationToken cancellationToken = new());
}