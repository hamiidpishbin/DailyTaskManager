namespace DailyTaskManager.Application.Models.Identity;

public record SignUpDto
{
  public string UserName { get; set; } = default!;
  public string DisplayName { get; set; } = default!;
  public string Email { get; set; } = default!;
  public string Password { get; set; } = default!;
}