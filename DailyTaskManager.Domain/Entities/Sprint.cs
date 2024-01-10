namespace DailyTaskManager.Domain.Entities;

public class Sprint
{
  public required Guid Id { get; set; }
  public required string Name { get; set; } = string.Empty;
  public required DateOnly StartDate { get; set; }
  public required DateOnly EndDate { get; set; }
  public List<SprintTask> SprintTasks { get; set; } = new();
}