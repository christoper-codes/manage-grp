using FluentValidation;
using manage_grp.Server.DTOs;
using manage_grp.Server.Forms;
using manage_grp.Server.Domain.Services;

public class DocumentTypeRequirementDtoValidator : AbstractValidator<DocumentRequirementDto>
{
    public DocumentTypeRequirementDtoValidator(BudgetaryKeyDocumentTypeBudgetaryKeyService budgetaryKeyDocumentTypeBudgetaryKeyService, ResourceDistributionDocumentTypeResourceDistributionService tenderDocumentTypeResourceDistributionService)
    {
        RuleFor(x => x.BudgetaryKeyDocumentTypeBudgetaryKeyId)
            .ValidateBudgetaryKeyDocumentTypeBudgetaryKeyField(budgetaryKeyDocumentTypeBudgetaryKeyService);
        
        RuleFor(x => x.ResourceDistributionDocumentTypeResourceDistributionId)
            .ValidaTetenderDocumentTypeResourceDistributionField(tenderDocumentTypeResourceDistributionService);

        RuleFor(x => x.Purpose)
            .ValidateStringField("Nombre", 255);
        
        RuleFor(x => x.Description)
            .ValidateStringField("Descripción", 255);

        RuleFor(x => x.IsActive)
            .ValidateBooleanField("Estatus");
    }
}
