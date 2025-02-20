using FluentValidation;
using manage_grp.Server.DTOs;
using manage_grp.Server.Forms;
using manage_grp.Server.Domain.Services;

public class ResourceDistributionDocumentTypeDtoValidator : AbstractValidator<ResourceDistributionDocumentTypeDto>
{
    public ResourceDistributionDocumentTypeDtoValidator(DependencyService dependencyService)
    {
        RuleFor(x => x.DependencyId)
            .ValidateDependencyIdField(dependencyService);

        RuleFor(x => x.Name)
            .ValidateStringField("Nombre", 50);

        RuleFor(x => x.Description)
            .ValidateStringField("Descripción", 255);

        RuleFor(x => x.IsActive)
            .ValidateBooleanField("Estatus");

        RuleFor(x => x.Mandatory)
            .ValidateBooleanField("Obligatorio");
    }
}