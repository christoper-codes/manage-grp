using FluentValidation;
using manage_grp.Server.DTOs;
using manage_grp.Server.Forms;
using manage_grp.Server.Services;

public class ServiceTypeDtoValidator : AbstractValidator<ServiceTypeDto>
{
    public ServiceTypeDtoValidator(AreaService areaService)
    {
        RuleFor(x => x.AreaId)
            .ValidateAreaIdField(areaService);

        RuleFor(x => x.Name)
            .ValidateStringField("Nombre", 100);

        RuleFor(x => x.Description)
            .ValidateStringField("Descripción", 255);
    }
}