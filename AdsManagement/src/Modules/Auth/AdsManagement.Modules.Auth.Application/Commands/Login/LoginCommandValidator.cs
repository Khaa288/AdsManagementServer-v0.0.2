using AdsManagement.Modules.Auth.Application.Cryptos;
using AdsManagement.Modules.Auth.Domain.Repositories;
using FluentValidation;

namespace AdsManagement.Modules.Auth.Application.Commands;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator(
        IOfficerRepository officerRepository,
        ICryptoService cryptoService)
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Username cannot be empty")
            .EmailAddress()
            .WithMessage("Username must be an email address")
            .MustAsync(async (request, email, cancellation) =>
            {
                return await officerRepository.IsOfficerExistsByEmailAsync(request.Email);
            })
            .WithMessage("Account does not exists !");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password cannot be empty")
            .MustAsync(async (request, password, cancellation) =>
            {
                var officer = await officerRepository.GetOfficerByEmailAsync(request.Email);
        
                if (officer is null)
                    return false;
                return officer!.PasswordHash == cryptoService.HashPasswordWithSha256(request.Password);
            })
            .WithMessage("Password not true");
    }
}