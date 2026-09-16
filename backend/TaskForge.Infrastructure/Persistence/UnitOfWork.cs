using TaskForge.Application.Interfaces;
using TaskForge.Infrastructure.Persistence;

namespace TaskForge.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly TaskForgeDbContext _context;

    public UnitOfWork(TaskForgeDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}