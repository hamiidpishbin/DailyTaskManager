using System.ComponentModel.DataAnnotations;
using DailyTaskManager.Domain.Enums;

namespace DailyTaskManager.Domain.Entities;

public record DailyTask
{
  public required Guid Id { get; init; }
  public required string Title { get; init; } = string.Empty;
  public required DailyTaskState State { get; init; } = DailyTaskState.Planned;
  public string Comments { get; init; } = string.Empty;
  public required DateTime StartDate { get; init; } = DateTime.Now;
  public DateTime? EndDate { get; init; }
}