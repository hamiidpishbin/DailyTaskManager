namespace DailyTaskManager.Application.Models.Identity;

public record LoginDto
{
  public string Email { get; set; } = default!;
  public string Password { get; set; } = default!;
}