namespace DailyTaskManager.Application.Models.Sprint;

public record SprintDto
{
  public required string Name { get; set; }
  public required DateOnly StartDate { get; set; }
  public required DateOnly EndDate { get; set; }
}