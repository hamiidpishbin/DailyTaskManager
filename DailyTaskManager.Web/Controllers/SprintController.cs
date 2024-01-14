using DailyTaskManager.Application.Interfaces;
using DailyTaskManager.Application.Models.Sprint;
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

  [HttpPost]
  public async Task<IActionResult> Add(IEnumerable<SprintDto> sprints)
  {
    await sprintService.AddSprints(sprints);
    return Ok();
  }

  [HttpPut]
  public async Task<IActionResult> Edit(SprintUpdateDto request)
  {
    var result = await sprintService.EditSprint(request);
    return HandleResult(result);
  }

  [HttpDelete]
  public async Task<IActionResult> Delete([FromBody] string sprintId)
  {
    await sprintService.DeleteSprint(new Guid(sprintId));
    return Ok();
  }
}