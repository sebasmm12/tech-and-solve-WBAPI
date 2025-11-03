using FluentValidation;
using TechAndSolve.WBAPI.Clients.Application.Auth.Mappings;
using TechAndSolve.WBAPI.Clients.Application.Auth.Requests;
using TechAndSolve.WBAPI.Products.Domain.Interfaces;
using TechAndSolve.WBAPI.Products.Domain.Users;

namespace TechAndSolve.WBAPI.Clients.Application.Auth.Services;

public class AuthService
    (IUsersRepository usersRepository, 
     IUnitOfWork unitOfWork,
     ITokenService tokenService,
     IPasswordHashService passwordHashService,
     IValidator<LoginRequest> loginValidator,
     IValidator<UserRegisterRequest> userRegisterValidator): IAuthService
{
    public async Task<string> LoginAsync(LoginRequest loginRequest)
    {
        await loginValidator.ValidateAndThrowAsync(loginRequest);

        var user = await usersRepository.GetByEmailAsync(loginRequest.Email);

        var isPasswordValid = passwordHashService.Verify(user.Password, user.Salt, loginRequest.Password);

        if (!isPasswordValid)
            return string.Empty;

        var token = GetToken(user);

        return token;
    }

    public async Task<string> RegisterAsync(UserRegisterRequest userRegisterRequest)
    {
        await userRegisterValidator.ValidateAndThrowAsync(userRegisterRequest);

        var passwordHashDto = passwordHashService.Generate(userRegisterRequest.Password);

        var user = userRegisterRequest.ToUser(passwordHashDto);

        usersRepository.Add(user);

        await unitOfWork.SaveChangesAsync();

        var token = GetToken(user);

        return token;
    }

    private string GetToken(User user)
    {
        var tokenGenerationDto = user.ToTokenGenerationDto();

        var token = tokenService.Generate(tokenGenerationDto);

        return token;
    }
}