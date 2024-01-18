using AutoMapper;
using DailyTaskManager.Application.Interfaces;
using DailyTaskManager.Application.Models.SprintTask;
using DailyTaskManager.Domain.Common;
using DailyTaskManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DailyTaskManager.Application.Services;

public class SprintTaskService(IApplicationDbContext dbContext, IMapper mapper) : ISprintTaskService
{
  public async Task<ServiceResult<IEnumerable<SprintTaskDto>>> GetSprintTasksAsync(Guid sprintId)
  {
    var query = dbContext.SprintTasks.AsQueryable().AsNoTracking();
    var sprintTasks = await query.Where(st => st.Sprint.Id == sprintId).ToListAsync();
    var result = mapper.Map<IEnumerable<SprintTaskDto>>(sprintTasks);
    return ServiceResult<IEnumerable<SprintTaskDto>>.Success(result);
  }
  
  public async Task<ServiceResult<bool>> AddSprintTasksAsync(AddSprintTaskDto request)
  {
    var sprintInDb = await dbContext.Sprints.FindAsync(request.SprintId);
    if (sprintInDb is null) return ServiceResult<bool>.Failure("Sprint Not Found");

    var sprintTasksToBeSaved = request.SprintTasks
      .Where(requestSprintTask => sprintInDb.SprintTasks!.All(sprintTaskInDb => requestSprintTask.Title.Trim() != sprintTaskInDb.Title.Trim()))
      .ToList();
    
    sprintInDb.SprintTasks!.AddRange(mapper.Map<IEnumerable<SprintTask>>(sprintTasksToBeSaved));
    var saveResult = await dbContext.SaveChangesAsync() > 0;
    return saveResult
      ? ServiceResult<bool>.Success(true)
      : ServiceResult<bool>.Failure("Failed to Add Sprint Tasks");
  }

  public async Task<ServiceResult<bool>> UpdateSprintTaskAsync(SprintTaskDto request)
  {
    var sprintTaskInDb = await dbContext.SprintTasks.FindAsync(request.Id);
    if (sprintTaskInDb is null) return ServiceResult<bool>.Failure("Sprint Task Not Found");

    var sprintTask = mapper.Map<SprintTask>(request);
    dbContext.SprintTasks.Update(sprintTask);
    var saveResult = await dbContext.SaveChangesAsync() > 0;
    return saveResult
      ? ServiceResult<bool>.Success(true)
      : ServiceResult<bool>.Failure("Failed to Update Sprint Task");
  }
}