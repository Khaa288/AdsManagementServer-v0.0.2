using AdsManagement.Modules.Auth.Domain.Entities;
using AdsManagement.Modules.Auth.Domain.Repositories;
using AdsManagement.Modules.Auth.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace AdsManagement.Modules.Auth.Infrastructure.Domain.Repostitories;

public class WardRepository : IWardRepository
{
    private readonly AuthContext _authContext;

    public WardRepository(AuthContext authContext)
    {
        _authContext = authContext;
    }
    
    public async Task<bool> IsWardExistsByIdAsync(int wardId)
    {
        return await _authContext.Wards
            .AnyAsync(w => w.WardId == wardId);
    }

    public async Task<Ward?> GetWardByIdAsync(int wardId)
    {
        return await _authContext.Wards
            .FindAsync(wardId);
    }
}