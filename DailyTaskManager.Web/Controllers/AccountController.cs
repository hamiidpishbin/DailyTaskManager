using DailyTaskManager.Application.Interfaces;
using DailyTaskManager.Application.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DailyTaskManager.Web.Controllers;

[AllowAnonymous]
public class AccountController(IIdentityService identityService) : BaseApiController
{
  [HttpPost("Login")]
  public async Task<IActionResult> Login(LoginDto loginDto)
  {
    var result = await identityService.LoginAsync(loginDto);
    return HandleResult(result);
  }

  [HttpPost("Signup")]
  public async Task<IActionResult> Signup(SignUpDto signUpDto)
  {
    var result = await identityService.CreateUserAsync(signUpDto);
    return HandleResult(result);
  }
}