using TechAndSolve.WBAPI.Clients.Application.Auth.Requests;

namespace TechAndSolve.WBAPI.Clients.Application.Auth.Services;

public interface IAuthService
{
    Task<string> LoginAsync(LoginRequest loginRequest);

    Task<string> RegisterAsync(UserRegisterRequest userRegisterRequest);
}