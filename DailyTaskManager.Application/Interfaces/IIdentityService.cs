using DailyTaskManager.Application.Models.Identity;
using DailyTaskManager.Domain.Common;

namespace DailyTaskManager.Application.Interfaces;

public interface IIdentityService
{
  Task<ServiceResult<bool>> CreateUserAsync(SignUpDto signUpDto);
  Task<ServiceResult<UserDto>> LoginAsync(LoginDto loginDto);
  Task<AppUserDto> GetCurrentUser();
}