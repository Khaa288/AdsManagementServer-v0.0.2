using AdsManagement.Modules.Auth.Application.Contracts;

namespace Application.Commands.Login;

public class LoginCommand : CommandBase<string>
{
    public string Email { get; }
    public string Password { get; }

    public LoginCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }
}