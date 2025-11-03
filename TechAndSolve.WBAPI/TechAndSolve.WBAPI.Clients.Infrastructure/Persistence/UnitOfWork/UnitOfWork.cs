using TechAndSolve.WBAPI.Products.Domain.Interfaces;

namespace TechAndSolve.WBAPI.Clients.Infrastructure.Persistence.UnitOfWork;

public class UnitOfWork
    (ApplicationDbContext applicationDbContext): IUnitOfWork
{
    public async Task SaveChangesAsync() => 
        await applicationDbContext.SaveChangesAsync();

    public void Dispose() => 
        applicationDbContext.Dispose();
}