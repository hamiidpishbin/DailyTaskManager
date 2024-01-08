using System.Security.Claims;
using AutoMapper;
using DailyTaskManager.Application.Interfaces;
using DailyTaskManager.Application.Models.Identity;
using DailyTaskManager.Domain.Common;
using DailyTaskManager.Domain.Enums.ErrorType;
using DailyTaskManager.Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DailyTaskManager.Infrastructure.Services;

public class IdentityService(UserManager<AppUser> userManager,
    ITokenService tokenService,
    SignInManager<AppUser> signInManager,
    IHttpContextAccessor httpContextAccessor,
    IMapper mapper)
  : IIdentityService
{

  #region Public Methods
  public async Task<ServiceResult<UserDto>> LoginAsync(LoginDto loginDto)
  {
    var user = await userManager.FindByEmailAsync(loginDto.Email);

    if (user == null)
    {
      return ServiceResult<UserDto>.Failure(IdentityErrorType.IncorrectLoginCredentials.ToString());
    }

    var signInResult = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

    return signInResult.Succeeded
      ? ServiceResult<UserDto>.Success(GetUserDto(user))
      : ServiceResult<UserDto>.Failure(IdentityErrorType.IncorrectLoginCredentials.ToString());
  }

  public async Task<ServiceResult<bool>> CreateUserAsync(SignUpDto signUpDto)
  {
    if (signUpDto.Password != signUpDto.PasswordConfirm)
    {
      return ServiceResult<bool>.Failure(IdentityErrorType.PasswordConfirmationDoesNotMatch.ToString());
    }
    
    var userNameIsTaken = await userManager.Users.AnyAsync(user => user.UserName == signUpDto.UserName);
    if (userNameIsTaken)
    {
      return ServiceResult<bool>.Failure(IdentityErrorType.UserNameIsTaken.ToString());
    }

    var emailIsTaken = await userManager.Users.AnyAsync(user => user.Email == signUpDto.Email);
    if (emailIsTaken)
    {
      return ServiceResult<bool>.Failure(IdentityErrorType.EmailIsTaken.ToString());
    }

    var user = new AppUser
    {
      UserName = signUpDto.UserName,
      Email = signUpDto.Email,
      DisplayName = signUpDto.DisplayName
    };

    var createdUser = await userManager.CreateAsync(user, signUpDto.Password);

    return createdUser is not { Succeeded: true }
      ? ServiceResult<bool>.Failure(CommonErrorType.UnexpectedError.ToString())
      : ServiceResult<bool>.Success(true);
  }

  public async Task<AppUserDto> GetCurrentUser()
  {
    var currentUserEmail = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimValueTypes.Email);
    if (currentUserEmail is null) return new AppUserDto();
    var user = await userManager.FindByEmailAsync(currentUserEmail);

    return mapper.Map<AppUserDto>(user);
  }
  #endregion
  
  #region Private Methods
  private UserDto GetUserDto(AppUser user)
  {
    return new UserDto
    {
      DisplayName = user.DisplayName,
      Token = tokenService.CreateToken(mapper.Map<AppUserDto>(user))
    };
  }
  #endregion
}