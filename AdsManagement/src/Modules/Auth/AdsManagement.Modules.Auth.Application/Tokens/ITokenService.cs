using AdsManagement.Modules.Auth.Domain.Entities;

namespace AdsManagement.Modules.Auth.Application.Tokens;

public interface ITokenService
{
    string CreateToken(Officer officer, string tokenType);
}