namespace TechAndSolve.WBAPI.Products.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task SaveChangesAsync();
}