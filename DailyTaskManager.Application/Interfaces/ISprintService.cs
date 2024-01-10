using DailyTaskManager.Application.Models;
using DailyTaskManager.Domain.Entities;

namespace DailyTaskManager.Application.Interfaces;

public interface ISprintService
{
  Task<PagedResponse<Sprint>> GetPagedData(int currentPage, int pageSize);
}