using FluentValidation;
using TechAndSolve.WBAPI.Clients.Application.Clients.Requests;

namespace TechAndSolve.WBAPI.Clients.Application.Clients.Validators;

public class ClientRegisterValidator : AbstractValidator<ClientRegisterRequest>
{
    public ClientRegisterValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("El nombre es requerido.")
            .MaximumLength(100)
            .WithMessage("El nombre no puede exceder los 100 caracteres.");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("El apellido es requerido.")
            .MaximumLength(100)
            .WithMessage("El apellido no puede exceder los 100 caracteres.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("El correo electrónico es requerido.")
            .EmailAddress()
            .WithMessage("El correo electrónico no es válido.");


        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithMessage("El número de teléfono es requerido.")
            .MaximumLength(9)
            .WithMessage("El número de teléfono no puede exceder los 9 caracteres.")
            .Matches("^[0-9]+$")
            .WithMessage("El número de teléfono solo puede contener números.");

        RuleFor(x => x.Address)
            .NotEmpty()
            .WithMessage("La dirección es requerida.")
            .MaximumLength(200)
            .WithMessage("La dirección no puede exceder los 200 caracteres.");
    }
}