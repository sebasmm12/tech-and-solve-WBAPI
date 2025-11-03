using TechAndSolve.WBAPI.Clients.Application.Auth.Dtos;
using TechAndSolve.WBAPI.Clients.Application.Auth.Requests;
using TechAndSolve.WBAPI.Products.Domain.Users;

namespace TechAndSolve.WBAPI.Clients.Application.Auth.Mappings;

public static class UsersMapperExtensions
{
    public static User ToUser(this UserRegisterRequest userRegisterRequest, PasswordHashDto passwordHashDto)
    {
        var user = new User
        {
            Email = userRegisterRequest.Email,
            Password = passwordHashDto.PasswordHash,
            Role = "Admin",
            Salt = passwordHashDto.Salt
        };

        return user;
    }
}