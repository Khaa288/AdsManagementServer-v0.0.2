namespace AdsManagement.Modules.Auth.Application.Commands.RefreshAccessToken;

public class AccessTokenResponse
{
    public AccessTokenResponse(string token)
    {
        Token = token;
    }
    
    public string Token { get; set; }   
}