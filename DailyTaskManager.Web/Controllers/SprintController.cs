using DailyTaskManager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DailyTaskManager.Web.Controllers;

public class SprintController(ISprintService sprintService) : BaseApiController
{
  [HttpGet]
  public async Task<IActionResult> Get([FromQuery] int currentPage = 1, [FromQuery] int pageSize = 10)
  {
    var result = await sprintService.GetPagedData(currentPage, pageSize);
    return Ok(result);
  }
}