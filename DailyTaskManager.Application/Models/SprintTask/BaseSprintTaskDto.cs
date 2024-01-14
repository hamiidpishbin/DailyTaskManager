namespace DailyTaskManager.Application.Models.SprintTask;

public record BaseSprintTaskDto
{
  public required string Title { get; set; } = string.Empty;
  public string Comment { get; set; } = string.Empty;
}