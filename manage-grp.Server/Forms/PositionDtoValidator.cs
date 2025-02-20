using FluentValidation;
using manage_grp.Server.DTOs;
using manage_grp.Server.Forms;
using manage_grp.Server.Domain.Services;

public class PositionDtoValidator : AbstractValidator<PositionDto>
{
    public PositionDtoValidator(DependencyService dependencyService)
    {
        RuleFor(x => x.DependencyId)
            .ValidateDependencyIdField(dependencyService);

        RuleFor(p => p.Name)
            .ValidateStringField("Nombre", 50);

        RuleFor(p => p.Abbreviation)
            .ValidateStringField("Abreviación", 50);

        RuleFor(x => x.IsActive)
            .ValidateBooleanField("Estatus");
    }
}
