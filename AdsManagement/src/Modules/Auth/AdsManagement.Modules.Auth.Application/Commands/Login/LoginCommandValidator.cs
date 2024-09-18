using AdsManagement.Modules.Auth.Domain;
using FluentValidation;

namespace AdsManagement.Modules.Auth.Application.Commands;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator(IAuthRepository authRepository)
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Username cannot be empty")
            .EmailAddress()
            .WithMessage("Username must be an email address")
            .MustAsync(async (request, email, cancellation) =>
            {
                var officer = await authRepository.GetOfficerWithRolesPrivilegesByEmailAsync(request.Email);
                return officer is null;
            })
            .WithMessage("Account does not exists !");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password cannot be empty")
            .MustAsync(async (request, password, cancellation) =>
            {
                var officer = await authRepository.GetOfficerWithRolesPrivilegesByEmailAsync(request.Email);

                if (officer is not null)
                    return officer!.PasswordHash == request.Password;
                return false;

                // // PasswordHash validation will comeback later
                // return BCrypt.Net.BCrypt.Verify(password, user!.Password);
            })
            .WithMessage("Bad Credentials");
    }
}