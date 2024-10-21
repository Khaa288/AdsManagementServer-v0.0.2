using AdsManagement.Modules.Auth.Application.Contracts;

namespace AdsManagement.Modules.Auth.Application.Commands;

public class CreateNewAccessTokenByRefreshTokenCommand : CommandBase<CreateNewAccessTokenByRefreshTokenResponse>
{
    public string Token { get; }
    public CreateNewAccessTokenByRefreshTokenCommand(string token)
    {
        Token = token;
    }
}