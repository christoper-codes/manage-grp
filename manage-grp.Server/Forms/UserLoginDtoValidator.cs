using FluentValidation;
using manage_grp.Server.DTOs;
using System.Net.Mail;

public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
{
    public UserLoginDtoValidator()
    {
        RuleFor(x => x.UserNameOrEmail)
            .NotEmpty().WithMessage("El campo 'Nombre de Usuario o Email' no debe estar vac�o.")
            .NotNull().WithMessage("El campo 'Nombre de Usuario o Email' no debe ser nulo.")
            .Must(value => !IsEmail(value) || IsEmailValid(value)).WithMessage("El campo 'Email' debe tener una estructura v�lida.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("El campo 'Contrase�a' no debe estar vac�o.")
            .NotNull().WithMessage("El campo 'Contrase�a' no debe ser nulo.");
    }

    private static bool IsEmail(string value)
    {
        return value.Contains("@");
    }

    private static bool IsEmailValid(string email)
    {
        try
        {
            var addr = new MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}
