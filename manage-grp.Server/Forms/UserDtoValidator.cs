using FluentValidation;
using manage_grp.Server.Domain.Services;
using manage_grp.Server.DTOs;
using manage_grp.Server.Forms;
using manage_grp.Server.Services;

public class UserDtoValidator : AbstractValidator<UserDto>
{
    public UserDtoValidator(UserService userService, StateService stateService, MunicipalityService municipalityService,DependencyService dependencyService)
    {
        RuleFor(x => x.UserName)
            .ValidateStringField("Alias", 100);

        RuleFor(x => x.FirstName)
            .ValidateStringField("Primer Nombre", 100);

        RuleFor(x => x.Email)
            .ValidateEmailUserField(userService);

        RuleFor(x => x.Password)
            .ValidatePassword();

        RuleFor(x => x)
            .AtLeastOneSelected(
                stateService,
                municipalityService,
                dependencyService,
                x => x.StateId,
                x => x.MunicipalityId,
                x => x.DependencyId);
    }
}