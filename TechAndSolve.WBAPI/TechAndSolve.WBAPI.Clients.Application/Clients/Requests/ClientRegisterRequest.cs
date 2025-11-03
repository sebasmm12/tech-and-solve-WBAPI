namespace TechAndSolve.WBAPI.Clients.Application.Clients.Requests;

public record ClientRegisterRequest(
    string Name,
    string LastName,
    string Email,
    string PhoneNumber,
    string Address);