using AdsManagement.BuildingBlocks.Infrastructure;
using AdsManagement.Modules.Auth.Domain.Entities;
using AdsManagement.Modules.Auth.Domain.Repositories;
using AdsManagement.Modules.Auth.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace AdsManagement.Modules.Auth.Infrastructure.Domain.Repostitories;

public class TokenRepository : ITokenRepository
{
    private readonly AuthContext _authContext;
    
    public TokenRepository(AuthContext authContext)
    {
        _authContext = authContext;
    }
    
    public async Task<RefreshToken?> GetRefreshTokenByOfficerIdAsync(Guid officerId)
    {
        return await _authContext.Tokens
            .FirstOrDefaultAsync(token => token.OfficerId == officerId);
    }

    public async Task<bool> IsRefreshTokenExistsByOfficerIdAsync(Guid officerId)
    {
        return await _authContext.Tokens
            .AnyAsync(token => token.OfficerId == officerId);
    }

    public async Task AddRefreshTokenAsync(RefreshToken refreshToken)
    {
        await _authContext.Tokens.AddAsync(refreshToken);
    }

    public Task RemoveRefreshTokenAsync(RefreshToken refreshToken)
    {
        _authContext.Tokens.Remove(refreshToken);
        return Task.CompletedTask;
    }
}