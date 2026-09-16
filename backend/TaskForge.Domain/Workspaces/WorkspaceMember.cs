namespace TaskForge.Domain.Entities;

public class WorkspaceMember
{
    public Guid Id { get; set; }

    public Guid WorkspaceId { get; set; }
    public Guid UserId { get; set; }

    public WorkspaceRole Role { get; set; }

    public DateTime InvitedAt { get; set; }
    public DateTime? JoinedAt { get; set; }

    public Workspace Workspace { get; set; } = null!;
    public User User { get; set; } = null!;
}