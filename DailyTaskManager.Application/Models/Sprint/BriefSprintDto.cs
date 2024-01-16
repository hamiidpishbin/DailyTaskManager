namespace DailyTaskManager.Application.Models.Sprint;

public record BriefSprintDto : BaseSprintDto
{
  public Guid Id { get; set; }
}