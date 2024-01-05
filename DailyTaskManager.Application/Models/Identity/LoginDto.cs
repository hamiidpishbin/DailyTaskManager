namespace DailyTaskManager.Application.Models.Identity;

public record LoginDto
{
  public string Email { get; set; } = string.Empty;
  public string Password { get; set; } = string.Empty;
}