namespace DailyTaskManager.Application.Models.SprintTask;

public class AddSprintTaskDto
{
  public required Guid SprintId { get; set; }
  public IEnumerable<BaseSprintTaskDto> SprintTasks { get; set; } = Enumerable.Empty<BaseSprintTaskDto>();
}