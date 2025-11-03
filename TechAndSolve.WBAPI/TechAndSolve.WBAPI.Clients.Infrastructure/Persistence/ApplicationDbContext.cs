using Microsoft.EntityFrameworkCore;
using TechAndSolve.WBAPI.Products.Domain.Clients;
using TechAndSolve.WBAPI.Products.Domain.Users;

namespace TechAndSolve.WBAPI.Clients.Infrastructure.Persistence;

public class ApplicationDbContext
    (DbContextOptions<ApplicationDbContext> options): DbContext(options)
{
    public DbSet<Client> Clients { get; set; }

    public DbSet<User> Users { get; set; }
}