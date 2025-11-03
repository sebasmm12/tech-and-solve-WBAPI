namespace TechAndSolve.WBAPI.Clients.Application.Auth.Requests;

public record LoginRequest(
    string Email,
    string Password);