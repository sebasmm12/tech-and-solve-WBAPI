using FluentValidation;
using TechAndSolve.WBAPI.Clients.Application.Clients.Mappings;
using TechAndSolve.WBAPI.Clients.Application.Clients.Requests;
using TechAndSolve.WBAPI.Clients.Application.Clients.Responses;
using TechAndSolve.WBAPI.Products.Domain.Clients;
using TechAndSolve.WBAPI.Products.Domain.Interfaces;

namespace TechAndSolve.WBAPI.Clients.Application.Clients.Services;

public class ClientsService
    (IClientsRepository clientsRepository,
     IUnitOfWork unitOfWork,
     IValidator<ClientRegisterRequest> clientRegisterRequestValidator,
     IValidator<ClientUpdateRequest> clientUpdateRequestValidator): IClientsService
{
    public async Task<IEnumerable<ClientResponse>> GetAllAsync()
    {
        var clients = await clientsRepository.GetAllAsync();

        var clientsResponse = clients.Select(client => client.ToClientResponse());

        return clientsResponse;
    }

    public async Task<ClientResponse> GetByIdAsync(int id)
    {
        var client = await clientsRepository.GetByIdAsync(id);

        if (client is null)
            throw new KeyNotFoundException("Cliente no encontrado.");

        var clientResponse = client.ToClientResponse();

        return clientResponse;
    }

    public async Task<int> CreateAsync(ClientRegisterRequest clientRegisterRequest)
    {
        await clientRegisterRequestValidator.ValidateAndThrowAsync(clientRegisterRequest);

        var client = clientRegisterRequest.ToClient();

        clientsRepository.Add(client);

        await unitOfWork.SaveChangesAsync();

        return client.Id;
    }

    public async Task UpdateAsync(ClientUpdateRequest clientUpdateRequest)
    {
        await clientUpdateRequestValidator.ValidateAndThrowAsync(clientUpdateRequest);

        var client = await clientsRepository.GetByIdAsync(clientUpdateRequest.Id);

        clientUpdateRequest.ToClient(client!);

        clientsRepository.Update(client!);

        await unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var client = await clientsRepository.GetByIdAsync(id);

        if (client is null)
            throw new KeyNotFoundException("Cliente no encontrado.");

        clientsRepository.Delete(client);

        await unitOfWork.SaveChangesAsync();
    }
}