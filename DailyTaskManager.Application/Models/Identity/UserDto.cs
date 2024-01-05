namespace DailyTaskManager.Application.Models.Identity;

public class UserDto
{
  public string DisplayName { get; set; } = string.Empty;
  public string Token { get; set; } = string.Empty;
  public string? Image { get; set; } = string.Empty;
}