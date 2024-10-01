using AdsManagement.Modules.Advertisement.Domain.Entities;

namespace AdsManagement.Modules.Advertisement.Domain.Repositories;

public interface IDistrictRepository
{
    Task<District> GetDistrictByDistrictId(int districtId);
}