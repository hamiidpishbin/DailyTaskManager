namespace DailyTaskManager.Application.Models.Sprint;

public record SprintUpdateDto : SprintDto
{
  public Guid Id { get; set; }
}