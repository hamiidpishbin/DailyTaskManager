using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Ardalis.GuardClauses;
using DailyTaskManager.Application.Interfaces;
using DailyTaskManager.Application.Models.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DailyTaskManager.Infrastructure.Services;

public class TokenService(IConfiguration config) : ITokenService
{
  public string CreateToken(AppUserDto user)
  {
    var claims = new List<Claim>
    {
      new (ClaimTypes.Name, user.UserName),
      new (ClaimTypes.NameIdentifier, user.Id),
      new (ClaimTypes.Email, user.Email),
    };

    var tokenKey = config["TokenKey"];
    Guard.Against.Null(tokenKey, message: "Token Key Was Null Or Empty");
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
    var credits = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

    var tokenDescriptor = new SecurityTokenDescriptor
    {
      Subject = new ClaimsIdentity(claims),
      Expires = DateTime.Now.AddHours(1),
      SigningCredentials = credits,
    };

    var tokenHandler = new JwtSecurityTokenHandler();
    var token = tokenHandler.CreateToken(tokenDescriptor);

    return tokenHandler.WriteToken(token);
  }
}