using Microsoft.AspNetCore.Identity;

namespace DailyTaskManager.Infrastructure.Models;

public class AppUser : IdentityUser
{
  public string DisplayName { get; set; } = default!;
}