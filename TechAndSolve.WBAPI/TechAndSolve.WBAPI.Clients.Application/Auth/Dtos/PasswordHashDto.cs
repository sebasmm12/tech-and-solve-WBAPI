namespace TechAndSolve.WBAPI.Clients.Application.Auth.Dtos;

public record PasswordHashDto(
    string PasswordHash,
    string Salt);