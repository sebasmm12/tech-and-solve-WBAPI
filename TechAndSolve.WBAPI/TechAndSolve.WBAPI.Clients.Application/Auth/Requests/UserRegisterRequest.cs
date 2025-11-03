namespace TechAndSolve.WBAPI.Clients.Application.Auth.Requests;

public record UserRegisterRequest(
    string Email,
    string Password);