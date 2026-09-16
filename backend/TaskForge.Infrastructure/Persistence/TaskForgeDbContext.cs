using Microsoft.EntityFrameworkCore;
using TaskForge.Domain.Entities;

namespace TaskForge.Infrastructure.Persistence;

public class TaskForgeDbContext : DbContext
{
    public TaskForgeDbContext(DbContextOptions<TaskForgeDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Workspace> Workspaces => Set<Workspace>();
    public DbSet<WorkspaceMember> WorkspaceMembers => Set<WorkspaceMember>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskForgeDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}