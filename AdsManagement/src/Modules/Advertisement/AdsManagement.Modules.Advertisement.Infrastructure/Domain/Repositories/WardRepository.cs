using AdsManagement.Modules.Advertisement.Domain.Entities;
using AdsManagement.Modules.Advertisement.Domain.Repositories;

namespace AdsManagement.Modules.Advertisement.Infrastructure.Domain.Repositories;

internal class WardRepository : IWardRepository
{
    public Task<Ward> GetWardByWardId(int wardId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Ward>> GetWardsByDistrictId(int districtId)
    {
        throw new NotImplementedException();
    }
}