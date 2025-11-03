using TechAndSolve.WBAPI.Products.Domain.Bases;

namespace TechAndSolve.WBAPI.Products.Domain.Users;

public class User : EntityBase
{
    public string Email { get; set; } = default!;

    public string Password { get; set; } = default!;

    public string Salt { get; set; } = default!;

    public string Role { get; set; } = default!;
}