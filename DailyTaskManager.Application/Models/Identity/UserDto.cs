namespace DailyTaskManager.Application.Models.Identity;

public record UserDto
{
  public string DisplayName { get; set; } = default!;
  public string Token { get; set; } = default!;
  public string? Image { get; set; } = default!;
}