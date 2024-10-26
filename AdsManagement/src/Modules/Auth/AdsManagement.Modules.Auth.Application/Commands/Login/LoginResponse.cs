namespace AdsManagement.Modules.Auth.Application.Commands;

public class LoginResponse
{
    public LoginResponse(string access, string refresh)
    {
        Access = access;
        Refresh = refresh;
    }

    public string Access { get; set; }
    public string Refresh { get; set; }
}