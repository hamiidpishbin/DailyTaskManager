using System.Reflection;
using DailyTaskManager.Application.Interfaces;
using DailyTaskManager.Domain.Entities;
using DailyTaskManager.Domain.Enums;
using DailyTaskManager.Infrastructure.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DailyTaskManager.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser>, IApplicationDbContext
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
  {
    
  }

  public DbSet<DailyTask> Tasks => Set<DailyTask>();
  public DbSet<DelayedTask> DelayedTasks => Set<DelayedTask>();
  public DbSet<Sprint> Sprints => Set<Sprint>();
  
  public override async Task<int> SaveChangesAsync(
    CancellationToken cancellationToken = new())
  {
    return await base.SaveChangesAsync(cancellationToken);
  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    base.OnModelCreating(builder);
  }
}