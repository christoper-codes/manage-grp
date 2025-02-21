using FluentValidation;
using manage_grp.Server.DTOs;
using manage_grp.Server.Forms;
using manage_grp.Server.Domain.Services;

public class TenderPriceTypeDtoValidator : AbstractValidator<TenderPriceTypeDto>
{
    public TenderPriceTypeDtoValidator(DependencyService dependencyService)
    {
        RuleFor(x => x.DependencyId)
            .ValidateDependencyIdField(dependencyService);

        RuleFor(x => x.Name)
            .ValidateStringField("Nombre", 100);

        RuleFor(x => x.Description)
            .ValidateStringField("Descripción", 255);

        RuleFor(x => x.IsActive)
            .ValidateBooleanField("Estatus");
    }
}