namespace DailyTaskManager.Application.Models.Sprint;

public record SprintUpdateDto : BaseSprintDto
{
  public Guid Id { get; set; }
}