using AdsManagement.Modules.Advertisement.Domain.Entities;
using AdsManagement.Modules.Advertisement.Domain.Repositories;

namespace AdsManagement.Modules.Advertisement.Infrastructure.Domain.Repositories;

internal class DistrictRepository : IDistrictRepository
{
    public Task<District> GetDistrictByDistrictId(int districtId)
    {
        throw new NotImplementedException();
    }
}