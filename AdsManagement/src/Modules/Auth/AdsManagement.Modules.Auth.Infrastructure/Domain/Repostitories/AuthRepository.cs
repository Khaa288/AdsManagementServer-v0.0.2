using AdsManagement.Modules.Auth.Domain.Entities;
using AdsManagement.Modules.Auth.Domain.Repositories;
using AdsManagement.Modules.Auth.Infrastructure.Database;

using Microsoft.EntityFrameworkCore;

namespace AdsManagement.Modules.Auth.Infrastructure.Domain.Repostitories;

internal class AuthRepository : IAuthRepository
{
    private readonly AuthContext _authContext;

    internal AuthRepository(AuthContext authContext)
    {
        _authContext = authContext;
    }

    public async Task<Officer?> GetOfficerByIdAsync(Guid officerId)
    {
        return await _authContext.Officers.FindAsync(officerId);
    }
    
    public async Task<Officer?> GetOfficerWithRolesPrivilegesByEmailAsync(string email)
    {
        return await _authContext.Officers
            .Include(o => o.Role)
            .Include(o => o.Privileges)
            .FirstOrDefaultAsync(o => o.Email == email);
    }
    
    public async Task<bool> IsOfficerExistsByEmailAsync(string email)
    {
        return await _authContext.Officers.AnyAsync(o => o.Email == email);
    }
    
    // Add more here
}