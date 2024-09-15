using AdsManagement.Modules.Auth.Domain;
using AdsManagement.Modules.Auth.Domain.Entities;
using AdsManagement.Modules.Auth.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace AdsManagement.Modules.Auth.Infrastructure.Domain.Repostitories;

public class AuthRepository : IAuthRepository
{
    private readonly AuthContext _authContext;

    public AuthRepository(AuthContext authContext)
    {
        _authContext = authContext;
    }

    public async Task<Officer?> GetOfficerByIdAsync(Guid officerId)
    {
        return await _authContext.Officers.FindAsync(officerId);
    }
    
    public async Task<Officer?> GetOfficerWithRolesPrivilegesByIdAsync(Guid officerId)
    {
        return await _authContext.Officers
            .Include(o => o.Role)
            .Include(o => o.Privileges)
            .FirstOrDefaultAsync(o => o.OfficerId == officerId);
    }
    
    // Add more here
}