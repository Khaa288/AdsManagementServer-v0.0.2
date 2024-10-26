using AdsManagement.Modules.Auth.Application.Contracts;

namespace AdsManagement.Modules.Auth.Application.Commands;

public class LogoutCommand : CommandBase
{
    public string AccessToken { get; }

    public LogoutCommand(string accessToken)
    {
        AccessToken = accessToken;
    }
}