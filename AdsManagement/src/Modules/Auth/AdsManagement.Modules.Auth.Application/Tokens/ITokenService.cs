using AdsManagement.Modules.Auth.Domain.Entities;

namespace AdsManagement.Modules.Auth.Application.Tokens;

public interface ITokenService
{
    string CreateAccessToken(Officer officer, string tokenType);
    string CreateRefreshToken(Officer officer, DateTime expiryDate, string tokenType);
    Guid DecodeToken(string token);
    bool IsTokenExpired(string token);
    bool DecodableToken(string token);
}