using AdsManagement.Modules.Auth.Application.Tokens;
using AdsManagement.Modules.Auth.Domain.Repositories;
using FluentValidation;

namespace AdsManagement.Modules.Auth.Application.Commands;

public class LogoutCommandValidator : AbstractValidator<LogoutCommand>
{
    public LogoutCommandValidator(
        ITokenRepository tokenRepository,
        ITokenService tokenService)
    {
        RuleFor(x => x.AccessToken)
            .NotEmpty()
            .WithMessage("AccessToken cannot be empty")
            .MustAsync( async (request, accessToken, cancellation) =>
            {
                if (!tokenService.DecodableToken(request.AccessToken))
                {
                    return false;
                }
                
                return true;
            })
            .WithMessage("Token is not appropriate");
    }
}