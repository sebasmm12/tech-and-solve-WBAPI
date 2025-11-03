namespace TechAndSolve.WBAPI.Clients.Application.Clients.Requests;

public record ClientUpdateRequest(
    int Id,
    string Name,
    string LastName,
    string Email,
    string PhoneNumber,
    string Address);