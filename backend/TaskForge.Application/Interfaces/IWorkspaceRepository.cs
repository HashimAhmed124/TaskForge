using TaskForge.Domain.Entities;

namespace TaskForge.Application.Interfaces;

public interface IWorkspaceRepository
{
    Task<Workspace?> GetByIdAsync(Guid id);
    Task<Workspace?> GetBySlugAsync(string slug);
    Task AddAsync(Workspace workspace);
    Task<bool> SlugExistsAsync(string slug);
}