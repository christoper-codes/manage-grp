using FluentValidation;
using manage_grp.Server.DTOs;
using manage_grp.Server.Forms;
using manage_grp.Server.Services;

public class DocumentTypeDtoValidator : AbstractValidator<DocumentTypeDto>
{
    public DocumentTypeDtoValidator(DependencyService dependencyService)
    {
        RuleFor(x => x.DependencyId)
            .ValidateDependencyIdField(dependencyService);

        RuleFor(x => x.Name)
            .ValidateStringField("Nombre", 50);

        RuleFor(x => x.Description)
            .ValidateStringField("Descripción", 255);
    }
}