using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskForge.Domain.Entities;

namespace TaskForge.Infrastructure.Persistence.Configurations;

public class WorkspaceConfiguration : IEntityTypeConfiguration<Workspace>
{
    public void Configure(EntityTypeBuilder<Workspace> builder)
    {
        builder.HasKey(w => w.Id);

        builder.Property(w => w.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(w => w.Slug)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasIndex(w => w.Slug)
            .IsUnique();

        builder.HasOne(w => w.OwnerUser)
            .WithMany()
            .HasForeignKey(w => w.OwnerUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(w => w.Members)
            .WithOne(wm => wm.Workspace)
            .HasForeignKey(wm => wm.WorkspaceId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}