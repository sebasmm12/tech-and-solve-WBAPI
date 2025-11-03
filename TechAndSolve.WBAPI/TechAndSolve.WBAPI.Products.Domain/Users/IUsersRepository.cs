using TechAndSolve.WBAPI.Products.Domain.Interfaces;

namespace TechAndSolve.WBAPI.Products.Domain.Users;

public interface IUsersRepository : IRepository<User>
{
    Task<User> GetByEmailAsync(string email);

    Task<bool> ExistsAsync(string email);
}