namespace DailyTaskManager.Application.Models.SprintTask;

public record SprintTaskDto : BaseSprintTaskDto
{
  public Guid Id { get; set; }
}