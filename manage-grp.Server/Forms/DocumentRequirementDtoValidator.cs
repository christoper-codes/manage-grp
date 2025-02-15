using FluentValidation;
using manage_grp.Server.DTOs;
using manage_grp.Server.Forms;
using manage_grp.Server.Services;

public class DocumentTypeRequirementDtoValidator : AbstractValidator<DocumentRequirementDto>
{
    public DocumentTypeRequirementDtoValidator(BudgetaryKeyDocumentTypeService budgetaryKeyDocumentTypeService)
    {
        RuleFor(x => x.BudgetaryKeyDocumentTypeId)
            .ValidateDocumentRequirementIdField(budgetaryKeyDocumentTypeService);

        RuleFor(x => x.Purpose)
            .ValidateStringField("Nombre", 255);
        
        RuleFor(x => x.Description)
            .ValidateStringField("Descripción", 255);
    }
}
