using FluentValidation;
using TechAndSolve.WBAPI.Clients.Application.Auth.Requests;
using TechAndSolve.WBAPI.Products.Domain.Users;

namespace TechAndSolve.WBAPI.Clients.Application.Auth.Validators;

public class UserRegisterValidator : AbstractValidator<UserRegisterRequest>
{
    public UserRegisterValidator(IUsersRepository usersRepository)
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

                return !exists;
            })
            .WithMessage("El correo electrónico ya está en uso.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("La contraseña es requerida.");
    }
}