using TechAndSolve.WBAPI.Clients.Application.Clients.Requests;
using TechAndSolve.WBAPI.Clients.Application.Clients.Responses;

namespace TechAndSolve.WBAPI.Clients.Application.Clients.Services;

public interface IClientsService
{
    Task<IEnumerable<ClientResponse>> GetAllAsync();

    Task<ClientResponse> GetByIdAsync(int id);

    Task<int> CreateAsync(ClientRegisterRequest clientRegisterRequest);

    Task UpdateAsync(ClientUpdateRequest clientUpdateRequest);

    Task DeleteAsync(int id);
}