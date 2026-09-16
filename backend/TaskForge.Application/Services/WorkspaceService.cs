using TaskForge.Application.DTOs;
using TaskForge.Application.Interfaces;
using TaskForge.Domain.Entities;

namespace TaskForge.Application.Services;

public class WorkspaceService : IWorkspaceService
{
    private readonly IWorkspaceRepository _workspaceRepository;
    private readonly IWorkspaceMemberRepository _memberRepository;
    private readonly IUnitOfWork _unitOfWork;

    public WorkspaceService(
        IWorkspaceRepository workspaceRepository,
        IWorkspaceMemberRepository memberRepository,
        IUnitOfWork unitOfWork)
    {
        _workspaceRepository = workspaceRepository;
        _memberRepository = memberRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<WorkspaceDto> CreateWorkspaceAsync(string name, string slug, Guid ownerUserId)
    {
        if (await _workspaceRepository.SlugExistsAsync(slug))
        {
            throw new InvalidOperationException($"A workspace with slug '{slug}' already exists.");
        }

        var workspace = new Workspace
        {
            Id = Guid.NewGuid(),
            Name = name,
            Slug = slug,
            OwnerUserId = ownerUserId,
            IsDeleted = false,
            CreatedAt = DateTime.UtcNow
        };

        await _workspaceRepository.AddAsync(workspace);

        var ownerMembership = new WorkspaceMember
        {
            Id = Guid.NewGuid(),
            WorkspaceId = workspace.Id,
            UserId = ownerUserId,
            Role = WorkspaceRole.Owner,
            InvitedAt = DateTime.UtcNow,
            JoinedAt = DateTime.UtcNow
        };

        await _memberRepository.AddAsync(ownerMembership);

        await _unitOfWork.SaveChangesAsync();

        return new WorkspaceDto
        {
            Id = workspace.Id,
            Name = workspace.Name,
            Slug = workspace.Slug,
            OwnerUserId = workspace.OwnerUserId,
            CreatedAt = workspace.CreatedAt
        };
    }
}