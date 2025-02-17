using FluentValidation;
using manage_grp.Server.Domain.Services;
using manage_grp.Server.DTOs;
using manage_grp.Server.Forms;

public class DependencyDtoValidator : AbstractValidator<DependencyDto>
{
    public DependencyDtoValidator(MunicipalityService municipalityService)
    {
        RuleFor(x => x.MunicipalityId)
            .ValidateMunicipalityIdField(municipalityService);

        RuleFor(x => x.Rfc)
            .ValidateRfcField("RFC");

        RuleFor(x => x.Name)
            .ValidateStringField("Nombre", 50);

        RuleFor(x => x.Acronym)
            .ValidateStringField("acrónimo", 10);
    }
}
