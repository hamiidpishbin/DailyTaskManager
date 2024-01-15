using System.Text;
using System.Text.Json.Serialization;
using DailyTaskManager.Application.Interfaces;
using DailyTaskManager.Infrastructure.Data;
using DailyTaskManager.Infrastructure.Models;
using DailyTaskManager.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace DailyTaskManager.Web;

public static class WebServicesConfigurations
{
  public static IServiceCollection AddWebServices(this IServiceCollection services,
    IConfiguration config)
  {
    services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
    services.AddScoped<IIdentityService, IdentityService>();
    services.AddScoped<ITokenService, TokenService>();

    services.AddCors(options =>
    {
      options.AddPolicy("CorsPolicy",
        policyBuilder => { policyBuilder.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000"); });
    });

    services.AddIdentityCore<AppUser>()
      .AddEntityFrameworkStores<ApplicationDbContext>()
      .AddSignInManager<SignInManager<AppUser>>();

    var tokenKey = config["TokenKey"] ?? throw new InvalidOperationException();
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
    {
      opt.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = key,
        ValidateIssuer = false,
        ValidateAudience = false,
      };
    });

    services.AddControllers(options =>
    {
      var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
      options.Filters.Add(new AuthorizeFilter(policy));
    }).AddJsonOptions(options =>
    {
      options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

    return services;
  }
}