using AdsManagement.Modules.Auth.Application.Tokens;
using FluentValidation;

namespace AdsManagement.Modules.Auth.Application.Commands;

public class CreateNewAccessTokenByRefreshTokenCommandValidator : AbstractValidator<CreateNewAccessTokenByRefreshTokenCommand>
{
    public CreateNewAccessTokenByRefreshTokenCommandValidator(
        ITokenService tokenService)
    {
        RuleFor(x => x.Token)
            .NotEmpty()
            .WithMessage("RefreshToken cannot be empty")
            .Must((request, refreshToken, cancellation) =>
            {
                if (!tokenService.DecodableToken(request.Token))
                {
                    return false;
                }

                return true;
            })
            .WithMessage("RefreshToken is not appropriate")
            .Must( (request, refreshToken, cancellation) =>
            {
                if (tokenService.DecodableToken(request.Token))
                {
                    return tokenService.IsTokenExpired(request.Token);
                }

                return true;
            })
            .WithMessage("Token is expired");
    }
}