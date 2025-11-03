using TechAndSolve.WBAPI.Products.Domain.Bases;

namespace TechAndSolve.WBAPI.Products.Domain.Clients;

public class Client : EntityBase
{
    public string Name { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string Email { get; set; } = default!;

    public string PhoneNumber { get; set; } = default!;

    public string Address { get; set; } = default!;
}