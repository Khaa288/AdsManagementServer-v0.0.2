using AdsManagement.BuildingBlocks.Application.Constraints;
using AdsManagement.BuildingBlocks.Application.Constraints.Constants;
using AdsManagement.BuildingBlocks.Application.Constraints.Enums;
using AdsManagement.Modules.Auth.Application.Tokens;
using AdsManagement.Modules.Auth.Domain.Entities;

using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace AdsManagement.Modules.Auth.Infrastructure.Token;

public class TokenService : ITokenService
{
    private readonly TokensConfiguration _configuration;

    public TokenService(TokensConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string CreateToken(Officer officer, string tokenType = TokenTypeNames.Access)
    {
        var now = DateTime.Now;
        var issuer = _configuration.Issuer;
        var audience = _configuration.Audience;
        var key = Encoding.ASCII.GetBytes(_configuration.Key!);
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, officer.OfficerId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, officer.Email!),
            // new Claim(JwtRegisteredClaimNames.Jti, tokenId.ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, now.ToString(CultureInfo.InvariantCulture)),
            new Claim(ClaimTypes.Role, officer.Role!.RoleName),
        };
        
        claims.AddRange(officer.Privileges.Select(privilege => new Claim("privileges", privilege.PrivilegeName)));

        claims.Add(new Claim(HeaderConstraints.TokenType, tokenType));
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = now.AddMinutes((int)TokenLifeTimeDurations.AccessLifeTimeDuration),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature),
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}