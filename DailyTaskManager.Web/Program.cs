using DailyTaskManager.Application;
using DailyTaskManager.Infrastructure;
using DailyTaskManager.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddWebServices(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();