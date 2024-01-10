namespace DailyTaskManager.Application.Models;

public record Pagination
{
  public int CurrentPage { get; set; }
  public int PageSize { get; set; }
  public int TotalItems { get; set; }
  public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);
}