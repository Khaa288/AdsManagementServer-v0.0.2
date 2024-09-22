using AdsManagement.Modules.Advertisement.Domain.Entities;

namespace AdsManagement.Modules.Advertisement.Domain.Repositories;

public interface IAdvertisementPointRepository
{
    Task<List<AdvertisementPoint>> GetAllAdvertisementPoints();
    Task<AdvertisementPoint> GetAdvertisementPointByPointId(Guid pointId);
    Task<List<AdvertisementPoint>> GetAdvertisementPointsByWardId(int wardId);
    Task<List<AdvertisementPoint>> GetAdvertisementPointsByDistrictId(int districtId);
}