using AutoMapper;
using DailyTaskManager.Application.Interfaces;
using DailyTaskManager.Application.Models;
using DailyTaskManager.Application.Models.Sprint;
using DailyTaskManager.Domain.Common;
using DailyTaskManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DailyTaskManager.Application.Services;

public class SprintService(IApplicationDbContext dbContext, IMapper mapper) : ISprintService
{
  public async Task<PagedResponse<BriefSprintDto>> GetPagedData(int currentPage, int pageSize)
  {
    var query = dbContext.Sprints.AsQueryable().AsNoTracking();

    var items = await query.Skip((currentPage - 1) * pageSize)
      .Take(pageSize)
      .ToListAsync();

    return new PagedResponse<BriefSprintDto>
    {
      Data = mapper.Map<IEnumerable<BriefSprintDto>>(items),
      Pagination = new Pagination
      {
        CurrentPage = currentPage,
        PageSize = pageSize,
        TotalItems = items.Count
      }
    };
  }
  
  public async Task<PagedResponse<SprintDto>> GetPagedSprintsWithTasks(int currentPage, int pageSize)
  {
    var query = dbContext.Sprints.AsQueryable().AsNoTracking().Include(s => s.SprintTasks);

    var items = await query.Skip((currentPage - 1) * pageSize)
      .Take(pageSize)
      .ToListAsync();

    return new PagedResponse<SprintDto>
    {
      Data = mapper.Map<IEnumerable<SprintDto>>(items),
      Pagination = new Pagination
      {
        CurrentPage = currentPage,
        PageSize = pageSize,
        TotalItems = items.Count
      }
    };
  }

  public async Task AddSprints(IEnumerable<BaseSprintDto> sprints)
  {
    foreach (var sprint in sprints)
    {
      var query = dbContext.Sprints.AsQueryable();
      var sprintInDb = await query.FirstOrDefaultAsync(s => s.Name == sprint.Name);
      if (sprintInDb is not null) continue;
      await dbContext.Sprints.AddRangeAsync(mapper.Map<IEnumerable<Sprint>>(sprints));
    }
    
    await dbContext.SaveChangesAsync();
  }

  public async Task<ServiceResult<bool>> EditSprint(SprintUpdateDto sprintUpdateDto)
  {
    var sprintInDb = await dbContext.Sprints.FindAsync(sprintUpdateDto.Id);
    if (sprintInDb is null) return ServiceResult<bool>.Failure("Sprint Not Found");
    mapper.Map<Sprint>(sprintUpdateDto);
    var saveResult = await dbContext.SaveChangesAsync() > 0;
    return saveResult
      ? ServiceResult<bool>.Success(true)
      : ServiceResult<bool>.Failure("Failed To Update Sprint");
  }

  public async Task DeleteSprint(Guid sprintId)
  {
    var sprintInDb = await dbContext.Sprints.FindAsync(sprintId);
    if (sprintInDb is not null)
    {
      sprintInDb.IsDeleted = true;
      await dbContext.SaveChangesAsync();
    }
  }
}