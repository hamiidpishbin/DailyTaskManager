namespace DailyTaskManager.Domain.Enums;

public class DelayedTask
{
  public Guid Id { get; set; }
  public DateTime DelayedTo { get; set; }
}