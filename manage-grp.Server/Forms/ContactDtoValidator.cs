using FluentValidation;
using manage_grp.Server.DTOs;
using manage_grp.Server.Forms;
using manage_grp.Server.Services;

public class ContactDtoValidator : AbstractValidator<ContactDto>
{
    public ContactDtoValidator(DependencyService dependencyService, PositionService positionService, AreaService areaService,ContactService contactService)
    {
        RuleFor(x => x.DependencyId)
           .ValidateDependencyIdField(dependencyService);
        
        RuleFor(x => x.AreaId)
           .ValidateAreaIdField(areaService);

        RuleFor(x => x.PositionId)
            .ValidatePositionIdField(positionService);

        RuleFor(x => x.FirstName)
            .ValidateStringField("Primer Nombre", 50);

        RuleFor(x => x.Email)
            .ValidateEmailContactField(contactService);

        RuleFor(x => x.Phone)
            .ValidatePhoneField("Número de Teléfono");
    }
}
