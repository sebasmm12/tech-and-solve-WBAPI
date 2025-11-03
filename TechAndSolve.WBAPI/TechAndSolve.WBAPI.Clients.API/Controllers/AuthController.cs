using Microsoft.AspNetCore.Mvc;
using TechAndSolve.WBAPI.Clients.Application.Auth.Requests;
using TechAndSolve.WBAPI.Clients.Application.Auth.Services;

namespace TechAndSolve.WBAPI.Clients.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(
    IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginRequest loginRequest)
    {
        var token = await authService.LoginAsync(loginRequest);

        if (string.IsNullOrEmpty(token))
            return BadRequest("La contraseña o el usuario son incorrectos");

        return Ok(token);
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterRequest userRegisterRequest)
    {
        var token = await authService.RegisterAsync(userRegisterRequest);

        return Ok(token);
    }
}