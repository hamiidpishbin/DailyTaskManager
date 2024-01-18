using DailyTaskManager.Application.Interfaces;
using DailyTaskManager.Application.Models.SprintTask;
using Microsoft.AspNetCore.Mvc;

namespace DailyTaskManager.Web.Controllers;

public class SprintTaskController(ISprintTaskService sprintTaskService) : BaseApiController
{
  [HttpGet("{sprintId}")]
  public async Task<IActionResult> Get(string sprintId)
  {
    var result = await sprintTaskService.GetSprintTasksAsync(new Guid(sprintId));
    return HandleResult(result);
  }
  
  [HttpPost]
  public async Task<IActionResult> AddSprintTasks(AddSprintTaskDto request)
  {
    var result = await sprintTaskService.AddSprintTasksAsync(request);
    return HandleResult(result);
  }

  [HttpPut]
  public async Task<IActionResult> UpdateSprintTask(SprintTaskDto request)
  {
    var result = await sprintTaskService.UpdateSprintTaskAsync(request);
    return HandleResult(result);
  }
}