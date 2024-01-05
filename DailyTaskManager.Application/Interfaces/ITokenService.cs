using DailyTaskManager.Application.Models.Identity;

namespace DailyTaskManager.Application.Interfaces;

public interface ITokenService
{
  string CreateToken(AppUserDto user);
}