using TaskForge.Application.DTOs;

namespace TaskForge.Application.Interfaces;

public interface IWorkspaceService
{
    Task<WorkspaceDto> CreateWorkspaceAsync(string name, string slug, Guid ownerUserId);
}