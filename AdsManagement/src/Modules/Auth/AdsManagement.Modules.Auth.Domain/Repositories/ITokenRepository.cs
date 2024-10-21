using AdsManagement.Modules.Auth.Domain.Entities;

namespace AdsManagement.Modules.Auth.Domain.Repositories;

public interface ITokenRepository
{
    Task<RefreshToken?> GetRefreshTokenByOfficerIdAsync(Guid officerId);
    Task<bool> IsRefreshTokenExistsByOfficerIdAsync(Guid officerId);
    
    Task AddRefreshTokenAsync(RefreshToken refreshToken);
    Task RemoveRefreshTokenAsync(RefreshToken refreshToken);
}