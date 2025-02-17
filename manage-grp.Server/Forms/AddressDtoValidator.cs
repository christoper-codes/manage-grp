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
            .ValidateNumericIntField("Número Exterior", minValue:1);

        RuleFor(x => x.PostalCode)
        .ValidateStringLength("Código postal", 5);
    }
}
