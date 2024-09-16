using AdsManagement.Modules.Auth.Domain;
using FluentValidation;

namespace Application.Commands.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator(IAuthRepository authRepository)
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Username must be an email address");
        
        RuleFor(x => x.Password)
            // .NotEmpty()
            // .WithMessage("Password Cannot be empty")
            .MustAsync(async (request, password, cancellation) =>
            {
                var user = await authRepository.GetOfficerWithRolesPrivilegesByEmailAsync(request.Email);

                // if (user.PasswordHash == request.Password) 
                //     return false;
                // // return BCrypt.Net.BCrypt.Verify(password, user!.Password);
                return false;
            })
            .WithMessage("Invalid Password");
    }
}