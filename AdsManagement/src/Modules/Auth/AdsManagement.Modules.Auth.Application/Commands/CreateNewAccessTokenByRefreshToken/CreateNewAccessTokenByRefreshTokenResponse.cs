namespace AdsManagement.Modules.Auth.Application.Commands;

public class CreateNewAccessTokenByRefreshTokenResponse
{
    public CreateNewAccessTokenByRefreshTokenResponse(string accessToken)
    {
        AccessToken = accessToken;
    }
    
    public string AccessToken { get; set; }
}