using Microsoft.EntityFrameworkCore;
using TaskForge.Application.Interfaces;
using TaskForge.Domain.Entities;

namespace TaskForge.Infrastructure.Persistence.Repositories;

public class WorkspaceMemberRepository : IWorkspaceMemberRepository
{
    private readonly TaskForgeDbContext _context;

    public WorkspaceMemberRepository(TaskForgeDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(WorkspaceMember member)
    {
        await _context.WorkspaceMembers.AddAsync(member);
    }

    public async Task<bool> ExistsAsync(Guid workspaceId, Guid userId)
    {
        return await _context.WorkspaceMembers
            .AnyAsync(wm => wm.WorkspaceId == workspaceId && wm.UserId == userId);
    }
}