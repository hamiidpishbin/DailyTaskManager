namespace DailyTaskManager.Application.Models.SprintTask;

public record BaseSprintTaskDto
{
  public required string Title { get; set; }
  public string Comment { get; set; } = null!;
}