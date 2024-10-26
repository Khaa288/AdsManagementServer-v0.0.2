namespace AdsManagement.Modules.Auth.Application.Cryptos;

public interface ICryptoService
{
    string HashPasswordWithSha256(string password);
}