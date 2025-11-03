namespace TechAndSolve.WBAPI.Clients.Application.Clients.Responses;

public record ClientResponse(
    int Id,
    string Name,
    string LastName,
    string Email,
    string PhoneNumber,
    string Address);