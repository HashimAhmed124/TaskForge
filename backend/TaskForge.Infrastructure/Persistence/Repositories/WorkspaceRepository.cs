using Microsoft.EntityFrameworkCore;
using TaskForge.Application.Interfaces;
using TaskForge.Domain.Entities;
using TaskForge.Infrastructure.Persistence;

namespace TaskForge.Infrastructure.Persistence.Repositories;

public class WorkspaceRepository : IWorkspaceRepository
{
    private readonly TaskForgeDbContext _context;

    public WorkspaceRepository(TaskForgeDbContext context)
    {
        _context = context;
    }

    public async Task<Workspace?> GetByIdAsync(Guid id)
    {
        return await _context.Workspaces.FirstOrDefaultAsync(w => w.Id == id && !w.IsDeleted);
    }

    public async Task<Workspace?> GetBySlugAsync(string slug)
    {
        return await _context.Workspaces.FirstOrDefaultAsync(w => w.Slug == slug && !w.IsDeleted);
    }

    public async Task AddAsync(Workspace workspace)
    {
        await _context.Workspaces.AddAsync(workspace);
    }

    public async Task<bool> SlugExistsAsync(string slug)
    {
        return await _context.Workspaces.AnyAsync(w => w.Slug == slug);
    }
}