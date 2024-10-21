using AdsManagement.Modules.Auth.Domain.Entities;
using AdsManagement.Modules.Auth.Domain.Repositories;
using AdsManagement.Modules.Auth.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace AdsManagement.Modules.Auth.Infrastructure.Domain.Repostitories;

public class DistrictOfficerRepository : IDistrictOfficerRepository
{
    private readonly AuthContext _authContext;

    public DistrictOfficerRepository(AuthContext authContext)
    {
        _authContext = authContext;
    }
    
    public async Task<List<DistrictOfficer>> GetAllDistrictOfficerAsync()
    {
        return await _authContext.DistrictOfficers.ToListAsync();
    }

    public async Task<bool> IsDistrictOfficerExistsByIdAsync(Guid districtOfficerId)
    {
        return await _authContext.DistrictOfficers.AnyAsync(d => d.OfficerId == districtOfficerId);
    }

    public async Task CreateDistrictOfficerAsync(DistrictOfficer districtOfficer)
    {
        await _authContext.DistrictOfficers.AddAsync(districtOfficer);
    }

    public Task UpdateDistrictOfficerAsync(DistrictOfficer districtOfficer)
    {
        _authContext.DistrictOfficers.Update(districtOfficer);
        return Task.CompletedTask;
    }

    public Task DeleteDistrictOfficerAsync(DistrictOfficer districtOfficer)
    {
        _authContext.DistrictOfficers.Remove(districtOfficer);
        return Task.CompletedTask;
    }
}