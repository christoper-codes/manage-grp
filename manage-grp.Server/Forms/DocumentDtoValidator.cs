using FluentValidation;
using manage_grp.Server.DTOs;
using manage_grp.Server.Forms;
using manage_grp.Server.Services;

public class DocumentDtoValidator : AbstractValidator<DocumentDto>
{
    public DocumentDtoValidator(DocumentRequirementService documentRequirementService)
    {
        RuleFor(x => x.DocumentRequirementId)
            .ValidateDocumentRequirementIdField(documentRequirementService);

        RuleFor(x => x.Name)
            .ValidateStringField("Nombre", 50);

        RuleFor(x => x.MimeType)
            .ValidateMimeTypeField("MiME Type");

        RuleFor(x => x.Size)
            .ValidateNumericLongField("Tamaño de archivo", 0);

        RuleFor(x => x.Path)
            .ValidateStringField("Ruta de archivo", 50);
    }
}