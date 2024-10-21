using AdsManagement.Modules.Auth.Domain.Repositories;
using AdsManagement.Modules.Auth.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace AdsManagement.Modules.Auth.Infrastructure.Domain.Repostitories;

public class DistrictRepository : IDistrictRepository
{
    private readonly AuthContext _authContext;

    public DistrictRepository(AuthContext authContext)
    {
        _authContext = authContext;
    }
    public async Task<bool> IsDistrictExistsByIdAsync(int districtId)
    {
        return await _authContext.Districts
            .AnyAsync(d => d.DistrictId == districtId);
    }
}