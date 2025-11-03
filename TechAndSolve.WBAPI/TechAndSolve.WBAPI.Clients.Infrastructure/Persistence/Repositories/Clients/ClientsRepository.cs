using TechAndSolve.WBAPI.Products.Domain.Clients;

namespace TechAndSolve.WBAPI.Clients.Infrastructure.Persistence.Repositories.Clients;

public class ClientsRepository(
    ApplicationDbContext applicationDbContext) : Repository<Client>(applicationDbContext), IClientsRepository
{
}