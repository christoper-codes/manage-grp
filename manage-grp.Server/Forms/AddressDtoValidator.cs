using FluentValidation;
using manage_grp.Server.DTOs;
using manage_grp.Server.Forms;
using manage_grp.Server.Services;

public class AddressDtoValidator : AbstractValidator<AddressDto>
{
    public AddressDtoValidator(DependencyService dependencyService)
    {
        RuleFor(x => x.DependencyId)
            .ValidateDependencyIdField(dependencyService);

        RuleFor(x => x.Neighborhood)
            .ValidateStringField("Colonia", 50);

        RuleFor(x => x.Street)
            .ValidateStringField("Calle", 50);

        RuleFor(x => x.ExteriorNumber)
            .ValidateNumericIntField("N�mero Exterior", minValue:1);

        RuleFor(x => x.PostalCode)
        .ValidateStringLength("C�digo postal", 5);
    }
}
