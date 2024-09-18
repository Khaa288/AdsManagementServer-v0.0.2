namespace AdsManagement.Modules.Auth.Application.Commands;

public class LoginResponse
{
    public LoginResponse(string token)
    {
        Token = token;
    }

    public string Token { get; set; }
}