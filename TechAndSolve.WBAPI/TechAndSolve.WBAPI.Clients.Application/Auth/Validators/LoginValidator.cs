using FluentValidation;
using TechAndSolve.WBAPI.Clients.Application.Auth.Requests;
using TechAndSolve.WBAPI.Products.Domain.Users;

namespace TechAndSolve.WBAPI.Clients.Application.Auth.Validators;

public class LoginValidator : AbstractValidator<LoginRequest>
{
    public LoginValidator(IUsersRepository usersRepository)
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("El correo electrónico es requerido.")
            .EmailAddress()
            .WithMessage("El correo electrónico no es válido.")
            .MustAsync(async (email, _) =>
            {
                var exists = await usersRepository.ExistsAsync(email);

                return exists;
            })
            .WithMessage("No se encontró una cuenta con este correo electrónico.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("La contraseña es requerida.");
    }
}