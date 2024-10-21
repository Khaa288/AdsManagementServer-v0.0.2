using AdsManagement.Modules.Auth.Domain.Entities;
using AdsManagement.Modules.Auth.Domain.Repositories;
using AdsManagement.Modules.Auth.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace AdsManagement.Modules.Auth.Infrastructure.Domain.Repostitories;

public class WardOfficerRepository : IWardOfficerRepository
{
    private readonly AuthContext _authContext;

    public WardOfficerRepository(AuthContext authContext)
    {
        _authContext = authContext;
    }
    
    public async Task<List<WardOfficer>> GetAllWardOfficerAsync()
    {
        return await _authContext.WardOfficers.ToListAsync();
    }

    public async Task<bool> IsWardOfficerExistsByIdAsync(Guid wardOfficerId)
    {
        return await _authContext.WardOfficers.AnyAsync(w => w.OfficerId == wardOfficerId);
    }

    public async Task CreateWardOfficerAsync(WardOfficer wardOfficer)
    {
        await _authContext.WardOfficers.AddAsync(wardOfficer);
    }

    public Task UpdateWardOfficerAsync(WardOfficer wardOfficer)
    {
        _authContext.WardOfficers.Update(wardOfficer);
        return Task.CompletedTask;
    }

    public Task DeleteWardOfficerAsync(WardOfficer wardOfficer)
    {
        _authContext.WardOfficers.Remove(wardOfficer);
        return Task.CompletedTask;
    }
}