using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskForge.Domain.Entities;

namespace TaskForge.Infrastructure.Persistence.Configurations;

public class WorkspaceMemberConfiguration : IEntityTypeConfiguration<WorkspaceMember>
{
    public void Configure(EntityTypeBuilder<WorkspaceMember> builder)
    {
        builder.HasKey(wm => wm.Id);

        // Store enum as a string not as in int
        builder.Property(wm => wm.Role)
        .HasConversion<string>()
        .HasMaxLength(20)
        .IsRequired();

        // Enforce: one membership per role (Workspace, User) pair
        builder.HasIndex(wm => new { wm.WorkspaceId, wm.UserId })
        .IsUnique();

        builder.HasOne(wm => wm.User)
        .WithMany(u => u.WorkspaceMemberships)
        .HasForeignKey(wm => wm.UserId)
        .OnDelete(DeleteBehavior.Cascade);

        builder.Property(wm => wm.InvitedAt)
        .IsRequired();
    }
}