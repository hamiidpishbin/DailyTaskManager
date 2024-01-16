using DailyTaskManager.Application.Models;
using DailyTaskManager.Application.Models.Sprint;
using DailyTaskManager.Domain.Common;
using DailyTaskManager.Domain.Entities;

namespace DailyTaskManager.Application.Interfaces;

public interface ISprintService
{
  Task<PagedResponse<BriefSprintDto>> GetPagedData(int currentPage, int pageSize);
  Task AddSprints(IEnumerable<BaseSprintDto> sprints);
  Task DeleteSprint(Guid sprintId);
  Task<ServiceResult<bool>> EditSprint(SprintUpdateDto sprintUpdateDto);
  Task<PagedResponse<SprintDto>> GetPagedSprintsWithTasks(int currentPage, int pageSize);
}