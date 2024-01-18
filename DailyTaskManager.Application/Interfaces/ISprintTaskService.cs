using DailyTaskManager.Application.Models.SprintTask;
using DailyTaskManager.Domain.Common;
using DailyTaskManager.Domain.Entities;

namespace DailyTaskManager.Application.Interfaces;

public interface ISprintTaskService
{
  Task<ServiceResult<IEnumerable<SprintTaskDto>>> GetSprintTasksAsync(Guid sprintId);
  Task<ServiceResult<bool>> AddSprintTasksAsync(AddSprintTaskDto request);
  Task<ServiceResult<bool>> UpdateSprintTaskAsync(SprintTaskDto request);
}