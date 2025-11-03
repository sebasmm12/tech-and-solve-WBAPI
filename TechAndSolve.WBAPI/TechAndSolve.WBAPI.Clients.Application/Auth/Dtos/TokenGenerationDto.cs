namespace TechAndSolve.WBAPI.Clients.Application.Auth.Dtos;

public record TokenGenerationDto(
    int userId,
    string email,
    string role);