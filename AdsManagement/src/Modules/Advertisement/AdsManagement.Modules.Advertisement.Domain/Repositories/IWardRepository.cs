using AdsManagement.Modules.Advertisement.Domain.Entities;

namespace AdsManagement.Modules.Advertisement.Domain.Repositories;

public interface IWardRepository
{
    Task<Ward> GetWardByWardId(int wardId);
    Task<List<Ward>> GetWardsByDistrictId(int districtId);
}