namespace TaskForge.Domain.Entities;

public class Workspace
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public Guid OwnerUserId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }

    public User OwnerUser { get; set; } = null!;

    public ICollection<WorkspaceMember> Members { get; set; } = new List<WorkspaceMember>();
}