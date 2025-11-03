using TechAndSolve.WBAPI.Clients.Application.Auth.Dtos;
using TechAndSolve.WBAPI.Products.Domain.Users;

namespace TechAndSolve.WBAPI.Clients.Application.Auth.Mappings;

public static class TokenMapperExtensions
{
    public static TokenGenerationDto ToTokenGenerationDto(this User user)
    {
        var tokenGenerationDto = new TokenGenerationDto(
            user.Id,
            user.Email,
            user.Role);

        return tokenGenerationDto;
    }
}