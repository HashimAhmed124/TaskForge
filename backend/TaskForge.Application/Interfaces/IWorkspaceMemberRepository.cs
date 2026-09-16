using TaskForge.Domain.Entities;

namespace TaskForge.Application.Interfaces;

public interface IWorkspaceMemberRepository
{
    Task AddAsync(WorkspaceMember member);
    Task<bool> ExistsAsync(Guid workspaceId, Guid userId);
}