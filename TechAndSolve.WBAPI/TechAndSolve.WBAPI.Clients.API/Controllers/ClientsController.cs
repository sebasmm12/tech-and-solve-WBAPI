using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechAndSolve.WBAPI.Clients.Application.Clients.Requests;
using TechAndSolve.WBAPI.Clients.Application.Clients.Services;

namespace TechAndSolve.WBAPI.Clients.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class ClientsController
    (IClientsService clientsService): ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var clients = await clientsService.GetAllAsync();

        return Ok(clients);
    }

    [HttpGet("{clientId:int}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int clientId)
    {
        var client = await clientsService.GetByIdAsync(clientId);

        return Ok(client);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] ClientRegisterRequest clientRegisterRequest)
    {
        var clientId = await clientsService.CreateAsync(clientRegisterRequest);

        return Ok(clientId);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] ClientUpdateRequest clientUpdateRequest)
    {
        await clientsService.UpdateAsync(clientUpdateRequest);

        return NoContent();
    }

    [HttpDelete("{clientId:int}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int clientId)
    {
        await clientsService.DeleteAsync(clientId);

        return NoContent();
    }
}