using DailyTaskManager.Application;
using DailyTaskManager.Infrastructure;
using DailyTaskManager.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddWebServices(builder.Configuration);

var app = builder.Build();

app.UseCors("CorsPolicy");

app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();

app.Run();