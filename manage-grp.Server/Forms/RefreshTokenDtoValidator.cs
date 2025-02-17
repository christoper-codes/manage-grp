using FluentValidation;
using manage_grp.Server.DTOs;
using manage_grp.Server.Forms;

public class RefreshTokenDtoValidator : AbstractValidator<RefreshTokenDto>
{
    public RefreshTokenDtoValidator()
    {
        RuleFor(x => x.AccessToken)
            .ValidateStringField("AccessToken", 50);

        RuleFor(x => x.RefreshToken)
            .ValidateStringField("RefreshToken", 50);
    }
}
