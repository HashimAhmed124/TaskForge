namespace TaskForge.Application.Interfaces;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}