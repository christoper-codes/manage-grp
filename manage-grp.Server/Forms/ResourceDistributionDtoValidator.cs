using FluentValidation;
using manage_grp.Server.DTOs;
using manage_grp.Server.Forms;
using manage_grp.Server.Services;

public class ResourceDistributionDtoValidator : AbstractValidator<ResourceDistributionDto>
{
    public ResourceDistributionDtoValidator(BudgetaryKeyService budgetaryKeyService, AreaService areaService)
    {
        RuleFor(x => x.AreaId)
            .ValidateAreaIdField(areaService);

        RuleFor(x => x.BudgetaryKeyId)
            .ValidateBudgetaryKeyIdField(budgetaryKeyService);

        RuleFor(x => x.RequestNumber)
            .ValidateStringField("Número de solicitud", 50);

        RuleFor(x => x.ResourceNumber)
            .ValidateStringField("Número de recurso", 50);

        RuleFor(x => x.Concept)
            .ValidateStringField("Concepto", 255);

        RuleFor(x => x.Amount)
            .ValidateNumericDecimalField("Monto", minValue: 0);

        RuleFor(x => x)
            .ValidateLocation(x => x.Latitude, x => x.Longitude);
    }
}