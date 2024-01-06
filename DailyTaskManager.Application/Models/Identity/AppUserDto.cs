namespace DailyTaskManager.Application.Models.Identity;

public record AppUserDto
{
  public string Id { get; set; } = default!;
  public string UserName { get; set; } = default!;
  public string Email { get; set; } = default!;
}