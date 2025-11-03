using TechAndSolve.WBAPI.Clients.Application.Clients.Requests;
using TechAndSolve.WBAPI.Clients.Application.Clients.Responses;
using TechAndSolve.WBAPI.Products.Domain.Clients;

namespace TechAndSolve.WBAPI.Clients.Application.Clients.Mappings;

public static class ClientsMapperExtensions
{
    public static ClientResponse ToClientResponse(this Client client)
    {
        var clientResponse = new ClientResponse(
            client.Id,
            client.Name,
            client.LastName,
            client.Email,
            client.PhoneNumber,
            client.Address);

        return clientResponse;
    }

    public static Client ToClient(this ClientRegisterRequest clientRegisterRequest)
    {
        var client = new Client
        {
            Name = clientRegisterRequest.Name,
            LastName = clientRegisterRequest.LastName,
            Email = clientRegisterRequest.Email,
            PhoneNumber = clientRegisterRequest.PhoneNumber,
            Address = clientRegisterRequest.Address
        };

        return client;
    }

    public static Client ToClient(this ClientUpdateRequest clientUpdateRequest, Client client)
    {
        client.Name = clientUpdateRequest.Name;
        client.LastName = clientUpdateRequest.LastName;
        client.Email = clientUpdateRequest.Email;
        client.PhoneNumber = clientUpdateRequest.PhoneNumber;
        client.Address = clientUpdateRequest.Address;
            
        return client;
    }
}