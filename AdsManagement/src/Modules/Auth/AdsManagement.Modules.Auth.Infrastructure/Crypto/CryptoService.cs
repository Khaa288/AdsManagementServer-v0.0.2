using System.Security.Cryptography;
using System.Text;
using AdsManagement.Modules.Auth.Application.Cryptos;

namespace AdsManagement.Modules.Auth.Infrastructure.Password;

public class CryptoService : ICryptoService
{
    public CryptoService()
    {
    }
    
    public string HashPasswordWithSha256(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            
            StringBuilder hash = new StringBuilder();
            foreach (byte b in bytes)
            {
                hash.Append(b.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}