using AdsManagement.Modules.Auth.Application.Contracts;

namespace AdsManagement.Modules.Auth.Application.Commands;

public class LoginCommand : CommandBase<LoginResponse>
{
    public string Email { get; }
    public string Password { get; }

    public LoginCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }
}