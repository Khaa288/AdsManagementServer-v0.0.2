using AdsManagement.BuildingBlocks.Infrastructure;
using AdsManagement.Modules.Auth.Domain.Entities;
using AdsManagement.Modules.Auth.Domain.Repositories;
using AdsManagement.Modules.Auth.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace AdsManagement.Modules.Auth.Infrastructure.Domain.Repostitories;

public class TokenRepository : ITokenRepository
{
    private readonly AuthContext _authContext;
    private readonly IUnitOfWork _unitOfWork;
    
    public TokenRepository(
        AuthContext authContext,
        IUnitOfWork unitOfWork)
    {
        _authContext = authContext;
        _unitOfWork = unitOfWork;
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
        // await _unitOfWork.CommitAsync();
    }

    public async Task<bool> RemoveRefreshTokenAsync(Guid refreshTokenId)
    {
        var token = await _authContext.Tokens
            .FirstOrDefaultAsync(t => t.TokenId == refreshTokenId);
    }

    public Task<string> CreateAccessTokenAsync(RefreshToken refreshToken)
    {
        throw new NotImplementedException();
    }
}