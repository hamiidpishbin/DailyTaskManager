using DailyTaskManager.Application.Models.SprintTask;

namespace DailyTaskManager.Application.Models.Sprint;

public record SprintDto : BaseSprintDto
{
  public Guid Id { get; set; }
  public IEnumerable<SprintTaskDto> SprintTasks { get; set; } = Enumerable.Empty<SprintTaskDto>();
}