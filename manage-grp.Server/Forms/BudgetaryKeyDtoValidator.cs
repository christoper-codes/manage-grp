using FluentValidation;
using manage_grp.Server.DTOs;
using manage_grp.Server.Forms;
using manage_grp.Server.Domain.Services;

public class BudgetaryKeyDtoValidator : AbstractValidator<BudgetaryKeyDto>
{
    public BudgetaryKeyDtoValidator(DependencyService dependencyService, ContactService contactService)
    {
        RuleFor(x => x.DependencyId)
            .ValidateDependencyIdField(dependencyService);

        RuleFor(x => x.Key)
            .ValidateObjectOrString("Clave presupuestal");

        RuleFor(x => x.Amount)
            .ValidateNumericDecimalField("Monto", minValue:0);

        RuleFor(x => x.Concept)
            .ValidateStringField("Concepto", 255);

        RuleFor(x => x.ContactId)
            .ValidateContactIdField(contactService);

        RuleFor(x => x.Description)
            .ValidateStringField("Descripción", 255);

        RuleFor(x => x.IsActive)
            .ValidateBooleanField("Estatus");
    }
}