using TechAndSolve.WBAPI.Clients.Application.Auth.Dtos;

namespace TechAndSolve.WBAPI.Clients.Application.Auth.Services;

public interface IPasswordHashService
{
    PasswordHashDto Generate(string password);

    bool Verify(string password, string salt, string passwordHash);
}