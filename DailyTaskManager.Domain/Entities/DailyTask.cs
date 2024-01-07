using System.ComponentModel.DataAnnotations;
using DailyTaskManager.Domain.Enums;

namespace DailyTaskManager.Domain.Entities;

public record DailyTask
{
  [Required]
  public Guid Id { get; init; }

  [Required]
  public string Title { get; init; } = default!;
  [Required]
  public TaskState State { get; init; }
  public string Comments { get; init; } = default!;
  [Required]
  public DateTime StartDate { get; init; }
  public DateTime? EndDate { get; init; }
}