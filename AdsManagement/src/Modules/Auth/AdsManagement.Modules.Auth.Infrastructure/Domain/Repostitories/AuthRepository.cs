using AdsManagement.Modules.Auth.Domain;
using AdsManagement.Modules.Auth.Domain.Entities;
using AdsManagement.Modules.Auth.Infrastructure.Database;

namespace AdsManagement.Modules.Auth.Infrastructure.Domain.Repostitories;

public class AuthRepository : IAuthRepository
{
    private readonly AuthContext _authContext;

    public AuthRepository(AuthContext authContext)
    {
        _authContext = authContext;
    }

    public async Task<Officer?> GetByOfficerIdAsync(Guid officerId)
    {
        return await _authContext.Officers.FindAsync(officerId);
    }
    
    // Add more here
}