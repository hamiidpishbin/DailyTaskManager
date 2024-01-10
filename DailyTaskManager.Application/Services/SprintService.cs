using DailyTaskManager.Application.Interfaces;
using DailyTaskManager.Application.Models;
using DailyTaskManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DailyTaskManager.Application.Services;

public class SprintService(IApplicationDbContext dbContext) : ISprintService
{
  public async Task<PagedResponse<Sprint>> GetPagedData(int currentPage, int pageSize)
  {
    var query = dbContext.Sprints.AsQueryable();

    var totalItems = await query.CountAsync();

    var items = await query.Skip((currentPage - 1) * pageSize)
      .Take(pageSize)
      .ToListAsync();

    return new PagedResponse<Sprint>
    {
      Data = items,
      Pagination = new Pagination
      {
        CurrentPage = currentPage,
        PageSize = pageSize,
        TotalItems = totalItems
      }
    };
  }
}