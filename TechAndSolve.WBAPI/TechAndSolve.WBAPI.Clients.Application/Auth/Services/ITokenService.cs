using TechAndSolve.WBAPI.Clients.Application.Auth.Dtos;

namespace TechAndSolve.WBAPI.Clients.Application.Auth.Services;

public interface ITokenService
{
    string Generate(TokenGenerationDto tokenGenerationDto);
}