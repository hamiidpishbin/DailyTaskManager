namespace DailyTaskManager.Domain.Entities;

public record SprintTask
{
  public required Guid Id { get; set; }
  public required string Title { get; set; } = string.Empty;
  public string Comment { get; set; } = string.Empty;
  public required Sprint Sprint { get; set; }
}