using Microsoft.EntityFrameworkCore;
using TechAndSolve.WBAPI.Products.Domain.Users;

namespace TechAndSolve.WBAPI.Clients.Infrastructure.Persistence.Repositories.Users;

public class UsersRepository(
    ApplicationDbContext applicationDbContext) : Repository<User>(applicationDbContext), IUsersRepository
{
    public async Task<User> GetByEmailAsync(string email)
    {
        var user = await dbSet
            .FirstOrDefaultAsync(user => user.Email == email);

        return user!;
    }

    public async Task<bool> ExistsAsync(string email)
    {
        var exists = await dbSet
            .AnyAsync(user => user.Email == email);

        return exists;
    }
}