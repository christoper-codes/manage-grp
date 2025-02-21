using FluentValidation;
using manage_grp.Server.DTOs;
using manage_grp.Server.Forms;
using manage_grp.Server.Domain.Services;

public class BudgetKeyDefaultDtoValidator : AbstractValidator<BudgetKeyDefaultDto>
{
    public BudgetKeyDefaultDtoValidator(DependencyService dependencyService)
    {
        RuleFor(x => x.DependencyId)
            .ValidateDependencyIdField(dependencyService);

        RuleFor(x => x.Key)
            .ValidateObjectOrString("Clave presupuestal");

        RuleFor(x => x.IsActive)
            .ValidateBooleanField("Estatus");
    }
}
